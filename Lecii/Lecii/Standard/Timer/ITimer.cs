namespace Lecii.Standard {

	public interface ITimer {

		/// <summary>
		/// Remaining time in seconds
		/// </summary>
		double Remaining { get; }

		/// <summary>
		/// total seconds that want to capture
		/// </summary>
		double Seconds { get; set; }

		void Start();
		bool IsExpire();

	}

}
