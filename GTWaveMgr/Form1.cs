using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IronPython.Modules._ast;

namespace GTWave {
	public partial class Form1 : Form {
		private ImageList myImageList;

		private class ItemData {
			public string Name { get; set; }
			public Color Color { get; set; }
			public Brush Brush { get; }

			public ItemData(Color color) {
				Name = color.Name;
				Color = color;

				Brush = new SolidBrush(Color);
			}
		}

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {

			//control.Dock = DockStyle.Fill;
			//control.View = System.Windows.Forms.View.Details;

			control.OwnerDraw = true;
			control.FullRowSelect = true;


			control.Columns.Add("Color Name", 100);
			//control.Columns.Add("Color ", 200);

			var index = 1;

			AddItemData(control, index++, new ItemData(Color.Orange));
			AddItemData(control, index++, new ItemData(Color.Yellow));
			AddItemData(control, index++, new ItemData(Color.Red));
			AddItemData(control, index++, new ItemData(Color.Blue));
			AddItemData(control, index++, new ItemData(Color.Green));
			AddItemData(control, index++, new ItemData(Color.LightSkyBlue));
		}

		private void AddItemData(ListView list, int number, ItemData data) {
			var item = list.Items.Add(number.ToString());

			item.SubItems.Add(""); //No text is needed, graphics need to be drawn, among other things.

			item.Tag = data;
		}

		private void Control_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) {
			e.DrawDefault = true;
		}

		private void Control_DrawSubItem(object sender, DrawListViewSubItemEventArgs e) {
			if (e.ColumnIndex != 0) {
				e.DrawDefault = true;
				return;
			}

			var item = e.Item;
			var subItem = e.SubItem;
			var bounds = subItem.Bounds;

			var data = item.Tag as ItemData;
			var text = data.Name;

			var g = e.Graphics;
			g.Clip = new Region(bounds);

			var picWidth = 20;
			var picHeight = bounds.Height - 4;

			var rect = new Rectangle(bounds.X, bounds.Y, picWidth, picHeight);

			g.FillRectangle(data.Brush, rect);

			rect = bounds;
			rect.Offset(picWidth, 0);

			g.DrawString(text, item.Font, Brushes.Black, rect);
		}

		private void control_DrawItem(object sender, DrawListViewItemEventArgs e) {
			Debug.WriteLine(".. ");
			var item = e.Item;
			//var subItem = e.SubItem;
			var bounds = item.Bounds;

			var data = item.Tag as ItemData;
			var text = data.Name;

			var g = e.Graphics;
			g.Clip = new Region(bounds);

			var picWidth	= bounds.Width;
			var picHeight	= bounds.Height;

			var rect = new Rectangle(bounds.X, bounds.Y, picWidth, picHeight);

			g.FillRectangle(data.Brush, rect);

			rect = bounds;
			SizeF str_size = g.MeasureString("1", item.Font);
			int x = (int)((bounds.Height - str_size.Height) / 2);
			int y = (int)((bounds.Width - str_size.Width) / 2);
			rect.Offset(x-3, y+2);


			g.DrawString("23", item.Font, Brushes.Black, rect);
		}
	}
}
