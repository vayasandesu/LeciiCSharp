
namespace SWork.Legacy.Coordinate {


	public static class CoordinateExtension {

		/// <summary>
		/// check the rectangle is overlap
		/// </summary>
		/// <param name="tl_a">top left of first rectangle</param>
		/// <param name="br_a">bottom right of first rectangle</param>
		/// <param name="tl_b">top left of second rectangle</param>
		/// <param name="br_b">bottom right of second rectangle</param>
		/// <returns>true if overlap</returns>
		public static bool IsRectOverlap(Point tl_a, Point br_a, Point tl_b, Point br_b) {
			// If one rectangle is on left side of other  
			if(tl_a.X > br_b.X || tl_b.X > br_a.X) {
				return false;
			}

			// If one rectangle is above other  
			if(tl_a.Y < br_b.Y || tl_b.Y < br_a.Y) {
				return false;
			}
			return true;
		}

	}

}
