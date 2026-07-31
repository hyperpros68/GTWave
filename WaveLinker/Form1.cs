using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WaveLinker {
	public partial class Form1 : Form {
		private iTextSharp.text.Font fontS;
		private Paragraph lineSeparator;

		public Form1() {
			InitializeComponent();


			//한글 폰트를 읽어온다.
			BaseFont bf = BaseFont.CreateFont(@"C:\Windows\Fonts\malgun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
			//Font font = new Font(bf, 12, Font.BOLD | Font.UNDERLINE, CMYKColor.BLACK);
			fontS = new iTextSharp.text.Font(bf, 14.0f);
			fontS.SetStyle(1);
			fontS.SetColor(0, 0, 0);

			lineSeparator = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, CMYKColor.BLACK, Element.ALIGN_LEFT, 1)));
			// Set gap between line paragraphs.
			lineSeparator.SetLeading(0.5F, 0.5F);
		}
	}
}
