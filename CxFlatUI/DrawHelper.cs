using System.Drawing;
using System.Drawing.Drawing2D;

namespace CxFlatUI
{
	public static class DrawHelper
	{
		public static Color BackColor = ColorTranslator.FromHtml("#dadcdf");

		public static Color DarkBackColor = ColorTranslator.FromHtml("#90949a");

		public static Color LightBackColor = ColorTranslator.FromHtml("#F5F5F5");

		public static GraphicsPath CreateRoundRect(float x, float y, float width, float height, float radius)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(x + radius, y, x + width - radius * 2f, y);
			graphicsPath.AddArc(x + width - radius * 2f, y, radius * 2f, radius * 2f, 270f, 90f);
			graphicsPath.AddLine(x + width, y + radius, x + width, y + height - radius * 2f);
			graphicsPath.AddArc(x + width - radius * 2f, y + height - radius * 2f, radius * 2f, radius * 2f, 0f, 90f);
			graphicsPath.AddLine(x + width - radius * 2f, y + height, x + radius, y + height);
			graphicsPath.AddArc(x, y + height - radius * 2f, radius * 2f, radius * 2f, 90f, 90f);
			graphicsPath.AddLine(x, y + height - radius * 2f, x, y + radius);
			graphicsPath.AddArc(x, y, radius * 2f, radius * 2f, 180f, 90f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		public static GraphicsPath CreateUpRoundRect(float x, float y, float width, float height, float radius)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(x + radius, y, x + width - radius * 2f, y);
			graphicsPath.AddArc(x + width - radius * 2f, y, radius * 2f, radius * 2f, 270f, 90f);
			graphicsPath.AddLine(x + width, y + radius, x + width, y + height - radius * 2f + 1f);
			graphicsPath.AddArc(x + width - radius * 2f, y + height - radius * 2f, radius * 2f, 2f, 0f, 90f);
			graphicsPath.AddLine(x + width, y + height, x + radius, y + height);
			graphicsPath.AddArc(x, y + height - radius * 2f + 1f, radius * 2f, 1f, 90f, 90f);
			graphicsPath.AddLine(x, y + height, x, y + radius);
			graphicsPath.AddArc(x, y, radius * 2f, radius * 2f, 180f, 90f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		public static GraphicsPath CreateLeftRoundRect(float x, float y, float width, float height, float radius)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(x + radius, y, x + width - radius * 2f, y);
			graphicsPath.AddArc(x + width - radius * 2f, y, radius * 2f, radius * 2f, 270f, 90f);
			graphicsPath.AddLine(x + width, y + 0f, x + width, y + height);
			graphicsPath.AddArc(x + width - radius * 2f, y + height - 1f, radius * 2f, 1f, 0f, 90f);
			graphicsPath.AddLine(x + width - radius * 2f, y + height, x + radius, y + height);
			graphicsPath.AddArc(x, y + height - radius * 2f, radius * 2f, radius * 2f, 90f, 90f);
			graphicsPath.AddLine(x, y + height - radius * 2f, x, y + radius);
			graphicsPath.AddArc(x, y, radius * 2f, radius * 2f, 180f, 90f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		public static Color BlendColor(Color backgroundColor, Color frontColor)
		{
			double num = 0.0;
			double num2 = 1.0;
			int red = (int)((double)(int)backgroundColor.R * num2 + (double)(int)frontColor.R * num);
			int green = (int)((double)(int)backgroundColor.G * num2 + (double)(int)frontColor.G * num);
			int blue = (int)((double)(int)backgroundColor.B * num2 + (double)(int)frontColor.B * num);
			return Color.FromArgb(red, green, blue);
		}
	}
}
