using System;
using System.Collections.Generic;
using System.Text;

namespace Lecii.Standard.Coordinate {
	public struct Rect {

		/// <summary>
		/// Bottom Left
		/// </summary>
		public readonly Point2D BL;
		
		/// <summary>
		/// Top Right
		/// </summary>
		public readonly Point2D TR;

		/// <summary>
		/// Top left
		/// </summary>
		public Point2D TL => new Point2D(BL.X, TR.Y);

		/// <summary>
		/// bottom Right
		/// </summary>
		public Point2D BR => new Point2D(TR.X, BL.Y);

		public float Width => BL.X - TR.X;
		public float Height => TR.Y - BL.Y;

		public Point2D Center => new Point2D(Math.Abs(TR.X - BL.X) / 2, Math.Abs(TR.Y - BL.Y) / 2);

		public Rect(Point2D bottomLeft, Point2D topRight) {
			BL = bottomLeft;
			TR = topRight;
		}

		public bool IsOverlapWith(Rect other) {
			return CoordinateExtension.IsRectOverlap(TL, BR, other.TL, other.BR);
		}

	}
}
