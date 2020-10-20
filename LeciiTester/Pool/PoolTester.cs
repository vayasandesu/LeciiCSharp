using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Lecii.Pool {
	public class PoolTester {
	
		private class Demo {
			public static int Count { get; private set; }
			public readonly int id;
			public Demo() {
				id = Count++;
			}
		}

		private Demo Create() {
			return new Demo();
		}

		[Test]
		public void GetFromEmpty() {
			var pool = new Pool<Demo>(Create);
			var item = pool.Get();
			Assert.IsNotNull(item);
			Assert.AreEqual(0, item.id);
		}

		[Test]
		public void ReturnItem() {
			var pool = new Pool<Demo>(Create);
			var item = pool.Get();
			Assert.AreEqual(0, pool.Count);

			pool.Return(item);
			Assert.AreEqual(1, pool.Count);
		}


		[Test]
		public void RetriveUsable() {
			var pool = new Pool<Demo>(Create);
			pool.Return(pool.Get());
			Assert.AreEqual(1, pool.Count);

			var item = pool.Get();
			Assert.Less(item.id, Demo.Count);
			Assert.AreEqual(0, pool.Count);
		}

		[Test]
		public void NotStoreMoreThanLimit([Random(0, 1000, 10)]int max) {
			var pool = new Pool<Demo>(Create, max);
			var list = new List<Demo>();
			for(int i = 0; i < max  * 1.5f; i++) {
				list.Add(pool.Get());
			}

			for(int i = 0; i < list.Count; i++) {
				pool.Return(list[i]);
			}

			Assert.AreEqual(max, pool.Count);
		}

		[Test]
		public void LoopGetAndRestoreTest([Random(0, 1000, 10)] int times) {
			var pool = new Pool<Demo>(Create);
			for(int i = 0; i < times ; i++) {
				pool.Return(pool.Get());
			}

			Assert.AreEqual(1, pool.Count);
		}

	}

}
