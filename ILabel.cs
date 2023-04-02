using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

public class ILabel : Label
{
	private Font c = new Font("Segoe UI", 10f);

	private TextRenderingHint d;

	public TextRenderingHint TextRenderingHint
	{
		get
		{
			return d;
		}
		set
		{
			d = value;
		}
	}

	public ILabel()
	{
		Font = c;
		ForeColor = Color.FromArgb(200, 200, 200);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		e.Graphics.TextRenderingHint = d;
		base.OnPaint(e);
	}
}
