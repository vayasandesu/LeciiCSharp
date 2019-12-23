using System;
using System.Collections.Generic;
using System.Linq;

namespace Slime.Standard {

	/// <summary>
	/// Reusable pool
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable]
	public class Island<T> : IPool<T> {
		
		public int Population => ActivateCount + LazyCount;
		public int ActivateCount => _activeWorker.Count;
		public int LazyCount => _lazyWorker.Count;

		private CreationEventHandler<T> _birthSolution;
		private HashSet<T> _activeWorker;
		private Stack<T> _lazyWorker;
		
		private Island() {
			_lazyWorker = new Stack<T>();
			_activeWorker = new HashSet<T>();
		}

		public Island(Func<T> birthSolution) : this(){
			_birthSolution = birthSolution.Invoke;
		}

		public Island(CreationEventHandler<T> birthSolution) : this() {
			_birthSolution = birthSolution;
		}

		/// <summary>
		/// get the worker from island for work
		/// </summary>
		public T GetObject() {
			TryToGetWorker(out T worker);
			return worker;
		}

		/// <summary>
		/// get the worker from island for work
		/// </summary>
		public bool TryToGetWorker(out T worker) {
			worker = DetermineToGetWorker();
			_activeWorker.Add(worker);
			return true;
		}

		/// <summary>
		/// get the worker from island for work
		/// </summary>
		private T DetermineToGetWorker() {
			if(LazyCount > 0) {
				return CallLazyOne();
			} else {
				return BirthNewOne();
			}
		}

		/// <summary>
		/// return to the island and waiting for work
		/// </summary>
		public void ReturnObject(T obj) {
			Retire(obj, null);
		}

		/// <summary>
		/// return to the island and waiting for work
		/// </summary>
		public bool Retire(T entity, Action<T> onRetire = null) {
			bool isWorker = _activeWorker.Contains(entity);
			bool isLazy = _lazyWorker.Contains(entity);
			
			if (!isLazy && isWorker) {
				_activeWorker.Remove(entity);
				_lazyWorker.Push(entity);
				onRetire?.Invoke(entity);
				return true;
			}

			return false;
		}
		
		public void RetireAll(Action<T> OnRetire = null) {
			var array = _activeWorker.ToArray();
			foreach(var entity in array) {
				if(entity != null) Retire(entity, OnRetire);
			}
			_activeWorker.Clear();
		}

		/// <summary>
		/// create new instance to the pool and register to records
		/// </summary>
		private T BirthNewOne() {
			var obj = _birthSolution.Invoke();
			return obj;
		}
		
		/// <summary>
		/// get unuse object in pool
		/// </summary>
		private T CallLazyOne() {
			var obj = _lazyWorker.Pop();
			return obj;
		}

		public bool IsReusable() {
			return LazyCount > 0;
		}

		private T[] GetPopulations() {
			return _activeWorker.Concat(_lazyWorker).ToArray();
		}

		/// <summary>
		/// Destroy all population in the island
		/// </summary>
		public void Purify(Action<T> OnPurify) {
			var populations = GetPopulations();

			foreach(var entity in populations) {
				OnPurify?.Invoke(entity);
			}

			_activeWorker.Clear();
			_lazyWorker.Clear();
		}

	}

}
