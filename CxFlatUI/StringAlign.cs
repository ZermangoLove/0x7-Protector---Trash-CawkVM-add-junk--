using System.Drawing;

namespace CxFlatUI
{
	public static class StringAlign
	{
		public static StringFormat TopLeft => new StringFormat
		{
			Alignment = StringAlignment.Near,
			LineAlignment = StringAlignment.Near
		};

		public static StringFormat TopCenter => new StringFormat
		{
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Near
		};

		public static StringFormat TopRight => new StringFormat
		{
			Alignment = StringAlignment.Far,
			LineAlignment = StringAlignment.Near
		};

		public static StringFormat Left => new StringFormat
		{
			Alignment = StringAlignment.Near,
			LineAlignment = StringAlignment.Center
		};

		public static StringFormat Center => new StringFormat
		{
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Center
		};

		public static StringFormat Right => new StringFormat
		{
			Alignment = StringAlignment.Far,
			LineAlignment = StringAlignment.Center
		};

		public static StringFormat BottomLeft => new StringFormat
		{
			Alignment = StringAlignment.Near,
			LineAlignment = StringAlignment.Far
		};

		public static StringFormat BottomCenter => new StringFormat
		{
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Far
		};

		public static StringFormat BottomRight => new StringFormat
		{
			Alignment = StringAlignment.Far,
			LineAlignment = StringAlignment.Far
		};
	}
}
