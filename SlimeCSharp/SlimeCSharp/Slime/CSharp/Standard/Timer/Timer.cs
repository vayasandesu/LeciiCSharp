using System;

namespace Slime.Standard {
	
	[Serializable]
	public class Timer : ITimer {

		private double _seconds;
		private DateTime _start;

		public double Remaining {
			get {
				return Seconds - Spended;
			}
		}

		public double Spended {
			get {
				return (DateTime.Now - _start).TotalSeconds;
			}
		}

		public double Seconds {
			get => _seconds;
			set => _seconds = value;
		}

		public Timer(double seconds) {
			Seconds = seconds;
			Start();
		}
		
		public void Start() {
			_start = DateTime.Now;
		}

		public bool IsExpire() {
			return Remaining <= 0;
		}
		
	}

}
