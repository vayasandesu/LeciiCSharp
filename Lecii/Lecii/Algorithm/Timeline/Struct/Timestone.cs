namespace Lecii.Algorithm.Timeline {

	public class Timestone<T>: IRange {
		public T Value { get; set; }
		public double Start { get; private set; }
		public double End { get; private set; }

		public Timestone(T value, double start, double end) : this(start, end){
			Value = value;
		}

		public Timestone(double start, double end) {
			Start = start;
			End = end;
		}
	}

}
