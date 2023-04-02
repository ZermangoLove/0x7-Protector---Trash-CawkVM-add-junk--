using System.Windows.Forms;
using DarkUI.Config;

public class DarkTextBox : TextBox
{
	public DarkTextBox()
	{
		BackColor = Colors.LightBackground;
		ForeColor = Colors.LightText;
		base.Padding = new Padding(2, 2, 2, 2);
		base.BorderStyle = BorderStyle.FixedSingle;
	}
}
