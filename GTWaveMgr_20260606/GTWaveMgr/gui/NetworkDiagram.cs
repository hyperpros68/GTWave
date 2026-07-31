using MindFusion.Diagramming;
using MindFusion.Diagramming.Fluent;
using MindFusion.Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// https://www.google.com/search?newwindow=1&sca_esv=3a859606722aa11e&sca_upv=1&sxsrf=ADLYWILhfKQcRPMwWSOAm86GQneRfgMC-w:1721190504291&q=custom+shapenode+mindfusion+c%23&tbm=vid&source=lnms&fbs=AEQNm0DmKhoYsBCHazhZSCWuALW8mC6u5PFP1Ks3xvlaC0GwVFDphqJATVlK4Xe8ceC4SiPQ-LNnsfuQkOZlPe8yEeHmV4PvRpWxW6xOeSRTxNdclSQ51zVHx41D6q6e3SnU7AQ6nD2hkSwNPryQKAb6ZcZq-NlQEBOn1vQULOr2iwxVJugD5wRpTglOZdTneOGbMQQFD_f2MuYNrZ5SQm3QbZVeXJbrUw&sa=X&ved=2ahUKEwiEmeWknq2HAxVic_UHHR6dJ-IQ0pQJegQIDxAB&biw=1626&bih=854&dpr=1#fpstate=ive&vld=cid:5129237f,vid:iIlkYtXAxik,st:0

namespace GTWave.gui {
	public partial class NetworkDiagram : Form {

		private Color	mLinkColor	= Color.Aqua;
		private int		mSegment	= 2;
		private DashStyle mLinkStyle	= DashStyle.DashDotDot;
		private Image mBackgroundBkImage = null;


		public NetworkDiagram() {
			InitializeComponent();

			// 나중에 풀어서 되게 해야 한다..
			//main_diagram.UndoManager.UndoEnabled = true;

			cb_link_style.SelectedIndex = 3;

			//dv_netview.AllowInplaceEdit = true;

			Rectangle nodeBounds = new Rectangle(30, 30, 20, 20);

			//SvgNode node = main_diagram.Factory.CreateSvgNode(nodeBounds);
			SvgNode node = new SvgNode(main_diagram);
			SvgContent content = new SvgContent();
			content.LoadImage("../images/Pizza_Pepperoni.svg", nodeBounds);
			node.Content = content;
			node.Transparent = true;

			var label = node.AddLabel("Test\nGTWave");
			label.Font = new Font("Consolas", 11F, FontStyle.Italic);
			label.SetEdgePosition(2, 0, 0);

			ShapeNode shapeNode = new ShapeNode(main_diagram);
			shapeNode.Text = "asldfkj";
			
			//https://mindfusion.eu/onlinehelp/diagram.blazor/User_Defined_Node_Shapes_and_Custom_Drawing.htm
			string roundRect = @"
    r = Min(Width / 2, radius.X);
    MoveTo(r, 0);
    LineTo(Width - r, 0);
    ArcTo(Width, r, false, false, r, r);
    LineTo(Width, Height - r);
    ArcTo(Width - r, Height, false, false, r, r);
    LineTo(r, Height);
    ArcTo(0, Height - r, false, false, r, r);
    LineTo(0, r);
    ArcTo(r, 0, false, false, r, r);
    ";
			//main_diagram.Factory.CreateSvgNode(nodeBounds);
			/*
			Shape custom = new Shape(roundRect, "custom");
			custom.ControlPoints.Add(new ShapeControlPoint(
				"radius", 5, 1, 15, UnitType.Fixed, 0, 0, 0, UnitType.Fixed));
			shapeNode.Shape = custom;
			//shapeNode.Transparent = true;


			Shape custom1 = new Shape(

			// Outlines
			new ElementTemplate[]
			{
				new LineTemplate(10, 0, 90, 0),
				new ArcTemplate(80, 0, 20, 100, -90, 180),
				new LineTemplate(90, 100, 10, 100),
				new ArcTemplate(0, 0, 20, 100, 90, 180)
			},

			// Decorations
			new ElementTemplate[]
			{
				new ArcTemplate(0, 0, 20, 100, -90, 180)
			},

			// Text area
			new ElementTemplate[]
			{
				new LineTemplate(10, 0, 90, 0),
				new ArcTemplate(80, 0, 20, 100, -90, 180),
				new LineTemplate(90, 100, 10, 100),
				new BezierTemplate(10, 100, 35, 66, 35, 33, 10, 0)
			},

			FillMode.Winding, "DirectAccessStorage");
			*/
			/*
			var ctr = dv_netview.Diagram.Factory.CreateContainerNode(100, 0, 60, 200);
			ctr.Caption = "Editable label";
			ctr.CaptionFormat = new StringFormat() { Alignment = StringAlignment.Center }; // Doesn't work
			ctr.Foldable = false;
			//ctr.RotationAngle = 270;
			ctr.AutoGrow = true; // Doesn't work
			ctr.AutoShrink = true; // Doesn't work
			ctr.EnabledHandles = AdjustmentHandles.Move; // Doesn't work
			*/

			ShapeNode shapeNode1 = new ShapeNode(main_diagram);
			//shapeNode1.Shape = custom1;



			//MindFusion.Drawing.SolidBrush brush = new MindFusion.Drawing.SolidBrush(Color.Aqua); 
			//MindFusion.Drawing.HatchBrush brush1 = new MindFusion.Drawing.HatchBrush(;
			//main_diagram.DiagramLinkStyle.Stroke = brush;

			Debug.WriteLine(main_diagram.DiagramLinkStyle.Stroke.ToString());

			//main_diagram.DiagramLinkStyle.StrokeThickness = 3;

			//shapeNode.Text = "asldfkj";
			/*
			var shapelabel = shapeNode.AddLabel("Test\nGTWave");
			shapelabel.Font = new Font("Consolas", 11F, FontStyle.Italic);
			shapelabel.SetEdgePosition(2, 0, 0);
			*/
			//MindFusion.Diagramming.WinForms.Sha
			//shapeNode.Items.Add(shapeNode);
			//shapeList.AddNode(new ShapeNode());
			//Shape[] shapes = new Shape[1];
			//shapes[0] = custom1;

			shapeList.AddNode(node);
			shapeList.AddNode(shapeNode1);
			shapeList.AddNode(shapeNode);

			//ShapeLibrary lib = ShapeLibrary.LoadFrom("shapeLib.shl");
			//shapeListBox1.Shapes = lib.Shapes;
			//shapeListBox1.AddShape(custom);

			//var myRect = new ShapeNode(roundRect, "MyRect");

			//shapeList.AddNode(myRect);
			// ------------ Diagram 초기화 ----------
			dv_netview.Dock = DockStyle.Fill;
			main_diagram.BackBrush = new MindFusion.Drawing.SolidBrush(Color.FromArgb(240, 240, 240));
			main_diagram.BackgroundImage = new Bitmap(1, 1);
			dv_netview.BackColor = Color.FromArgb(240, 240, 240);
			overview1.BackColor = Color.FromArgb(240, 240, 240);
			main_ruler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

			tb_diagram_w.Text = main_diagram.Bounds.Width.ToString();
			tb_diagram_h.Text = main_diagram.Bounds.Height.ToString();
			main_diagram.DrawBackground += (s, e) => {
				DrawCustomBackground(e.Graphics);
			};
		}

		private void mf_netview_Click(object sender, EventArgs e) {

		}

		private void bt_close_ncd_Click(object sender, EventArgs e) {
			Close();
		}

		private void bt_load_ncd_Click(object sender, EventArgs e) {

			OpenFileDialog f = new OpenFileDialog();
			f.Filter = "구성도 files (*.mf) | *.mf;";

			if (f.ShowDialog() == DialogResult.OK) {
				dv_netview.LoadFromFile(f.FileName);
				mBackgroundBkImage = main_diagram.BackgroundImage;
				main_diagram.BackgroundImage = new Bitmap(1, 1);
				dv_netview.Invalidate();
				dv_netview.Refresh();
				dv_netview.ZoomToFit();
				//File = Image.FromFile(f.FileName);
				//main_diagram.BackgroundImage = File;
			}

			//dv_netview.LoadFromFile(".\\test.mf");
		}

		private void bt_save_ncd_Click(object sender, EventArgs e) {
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();

			saveFileDialog1.Filter = "구성도 파일|*.mf|모든 파일|*.*";
			saveFileDialog1.FilterIndex = 1;

			// 대화상자를 닫기 전에 디렉토리를 이전에 선택한 디렉토리로
			// 복원한지의 여부를 나타납니다.
			saveFileDialog1.RestoreDirectory = true;

			// 확장명을 입력하지 않을 때, 자동으로 확장자를 추가할 수 있습니다.
			saveFileDialog1.AddExtension = true;
			saveFileDialog1.DefaultExt = "mf";

			// 파일이 이미 존재하면 덮어쓰기 할지를 묻는 대화상자를 표시합니다.
			// 기본값: true
			saveFileDialog1.OverwritePrompt = true;

			// 저장할 위치의 초기 디렉토리를 설정합니다.
			// Environment.CurrentDirectory: 현재 디렉토리를 나타냅니다.
			saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;

			if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
				//this.Text = saveFileDialog1.FileName;
				dv_netview.SaveToFile(saveFileDialog1.FileName, true);
				/*
				using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName)) {
					sw.Write(textBox1.Text);
				}
				*/
			}
			
		}

		private void main_diagram_NodeClicked(object sender, NodeEventArgs e) {
			if (e.MouseButton == MouseButton.Right) {
				//Diagram diagram = (Diagram)sender;
				//Debug.WriteLine(sender.GetType().Name);

				//int x = main_ruler.Location.X + dv_netview.Location.X + (int)e.MousePosition.X;
				int x = Control.MousePosition.X - main_ruler.Location.X - dv_netview.Location.X - this.Location.X;
				//int y = main_ruler.Location.Y + dv_netview.Location.Y + (int)e.MousePosition.Y;
				int y = Control.MousePosition.Y - main_ruler.Location.Y - dv_netview.Location.Y - this.Location.Y;

				cm_node_menu.Show(this, new Point(x, y));//places the menu at the pointer position

				Debug.WriteLine(e.Node.Tag.ToString());
			}
		}

		private void bt_undo_Click(object sender, EventArgs e) {
			main_diagram.UndoManager.Undo();
		}

		private void bt_redo_Click(object sender, EventArgs e) {
			main_diagram.UndoManager.Redo();
		}

		private void dv_netview_ControlAdded(object sender, ControlEventArgs e) {
			Debug.WriteLine(sender.GetType().Name);
		}

		private void dv_netview_CreateEditControl(object sender, MindFusion.Diagramming.WinForms.InPlaceEditEventArgs e) {
			Debug.WriteLine(sender.GetType().Name);
		}

		int node_idx = 0;
		private void main_diagram_NodeCreated(object sender, NodeEventArgs e) {
			e.Node.Tag = node_idx++.ToString();
			Debug.WriteLine(e.Node.Tag.ToString());
		}

		// https://mindfusion.eu/demos/flowchartnet/start.htm
		private void main_diagram_LinkCreated(object sender, LinkEventArgs e) {
			//Debug.WriteLine(sender.GetType().Name);
			//MindFusion.Drawing.SolidBrush brush = new MindFusion.Drawing.SolidBrush(Color.Aqua);
			//DiagramLink link = new DiagramLink(e.Link.Parent);
			//link.Style.Stroke = brush;
			//e.Link.Pen = new MindFusion.Drawing.Pen(color);
			/*
			e.Link.Style = new DiagramLinkStyle {
				Stroke = new MindFusion.Drawing.SolidBrush(color),
				StrokeDashStyle	= DashStyle.DashDotDot
			};
			*/
			e.Link.Brush = new MindFusion.Drawing.SolidBrush(mLinkColor);
			
			int.TryParse(cb_link_segment.Text, out int outValue);
			if (outValue > 0 && outValue < 9) {
				e.Link.SegmentCount = outValue;
			}

			e.Link.Style = new DiagramLinkStyle {
				Stroke = new MindFusion.Drawing.SolidBrush(mLinkColor),
				StrokeDashStyle = mLinkStyle
			};
			e.Link.HeadPen = new MindFusion.Drawing.Pen(new MindFusion.Drawing.SolidBrush(mLinkColor), 1);
		}

		private void bt_link_color_Click(object sender, EventArgs e) {
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK) {
				//MindFusion.Drawing.SolidBrush brush = new MindFusion.Drawing.SolidBrush(cd.Color);
				mLinkColor	= cd.Color;
				//main_diagram.DiagramLinkStyle.Stroke = brush;
			}
		}

		private void main_diagram_LinkCreating(object sender, LinkValidationEventArgs e) {

		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			ComboBox box = (ComboBox)sender;
			if (box.SelectedIndex >= 0) {
				switch (box.SelectedIndex) {
					case 0:
						mLinkStyle = DashStyle.Solid;
						break;
					case 1:
						mLinkStyle = DashStyle.Dot;
						break;
					case 2:
						mLinkStyle = DashStyle.DashDot;
						break;
					case 3:
						mLinkStyle = DashStyle.DashDotDot;
						break;
					case 4:
						mLinkStyle = DashStyle.Dash;
						break;
				}
			}
		}

		private void tb_diagram_w_TextChanged(object sender, EventArgs e) {
			if (int.TryParse(tb_diagram_w.Text, out int width)) {
				if (width < 10) return;
				if (width < 50) width = 50;

				if (dv_netview.Diagram != null) {
					RectangleF currentBounds = dv_netview.Diagram.Bounds;
					dv_netview.Diagram.Bounds = new RectangleF(0, 0, (float)width, currentBounds.Height);
 
					main_ruler.Refresh();
					dv_netview.Refresh();
				}
			}
		}

		private void tb_diagram_h_TextChanged(object sender, EventArgs e) {
			if (int.TryParse(tb_diagram_h.Text, out int height)) {
				if (height < 10) return;
				if (height < 50) height = 50;

				if (dv_netview.Diagram != null) {
					RectangleF currentBounds = dv_netview.Diagram.Bounds;
					dv_netview.Diagram.Bounds = new RectangleF(0, 0, currentBounds.Width, (float)height);
 
					main_ruler.Refresh();
					dv_netview.Refresh();
				}
			}
		}

		private void bt_bk_image_Click(object sender, EventArgs e) {
			Image File;
			OpenFileDialog f = new OpenFileDialog();
			f.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";

			if (f.ShowDialog() == DialogResult.OK) {
				File = Image.FromFile(f.FileName);
				mBackgroundBkImage = File;
				main_diagram.BackgroundImage = new Bitmap(1, 1);
				dv_netview.Invalidate();
				dv_netview.Refresh();
				dv_netview.ZoomToFit();
			}
		}

		private void cm_node_menu_Opening(object sender, CancelEventArgs e) {

		}

		private void DrawCustomBackground(MindFusion.Drawing.IGraphics g) {
			using (System.Drawing.SolidBrush grayBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(240, 240, 240))) {
				g.FillRectangle(grayBrush, new System.Drawing.RectangleF(-10000, -10000, 30000, 30000));
			}

			using (System.Drawing.SolidBrush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White)) {
				g.FillRectangle(whiteBrush, main_diagram.Bounds);
			}

			if (mBackgroundBkImage == null) return;

			Image image = mBackgroundBkImage;
			float targetWidth = main_diagram.Bounds.Width;
			float targetHeight = main_diagram.Bounds.Height;

			if (targetWidth <= 0 || targetHeight <= 0) return;

			float ratioX = targetWidth / image.Width;
			float ratioY = targetHeight / image.Height;
			float ratio = Math.Min(ratioX, ratioY);

			float newWidth = image.Width * ratio;
			float newHeight = image.Height * ratio;

			float posX = (targetWidth - newWidth) / 2f;
			float posY = (targetHeight - newHeight) / 2f;

			g.DrawImage(image, posX, posY, newWidth, newHeight);
		}
	}
}
