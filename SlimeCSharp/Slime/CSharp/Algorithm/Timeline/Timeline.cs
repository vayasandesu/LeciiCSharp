using System.Collections.Generic;
using System.Linq;

namespace Slime.Algorithm.Timeline {

	/// <summary>
	/// Find object is in range of value.
	/// </summary>
	/// <typeparam name="T">type of value that store in collection</typeparam>
	public class Timeline<T> {
		
		private Timestone<T>[] _timestones;
		private Timestone<T> _cache;

		public Timeline(params Timestone<T>[] timestones) {
			_timestones = timestones.OrderBy(obj => obj.Start).ToArray();
		}

		private bool IsInCacheRange(double time) {
			return _cache != null
				&& _cache.Start >= time && _cache.End <= time;
		}

		public bool IsOutOfRange(double time) {
			try {
				var min = _timestones[0];
				var max = _timestones[_timestones.Length - 1];
				return time < min.Start
					|| time > max.End;
			} catch {
				return true;
			}
		}

		public Timestone<T> Get(double time) {
			if(IsInCacheRange(time))
				return _cache;
			else {
				_cache = Find(time, 0, _timestones.Length - 1);
				return _cache;
			}
		}

		public IEnumerable<Timestone<T>> AsEnumerable() {
			if(_timestones == null) {
				yield break;
			}

			foreach(var collection in _timestones) {
				yield return collection;
			}
		}

		private Timestone<T> Find(double time, int minKey, int maxKey) {
			if(minKey > maxKey) {
				return null;
			} else {
				int mid = (minKey + maxKey) / 2;
				var sub = _timestones[mid];
				if(time >= sub.Start && time <= sub.End) {
					return sub;
				} else if(time > sub.End) {
					// go right
					return Find(time, mid + 1, maxKey);
				} else if(time < sub.Start) {
					// go left
					return Find(time, minKey, mid - 1);
				} else {
					throw new System.Exception("Should not happen");
				}
			}
		}

	}

}