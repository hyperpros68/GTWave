//
// Copyright (c) 2022, MindFusion LLC - Bulgaria.
//

using System;
using System.Drawing;

using MindFusion.Diagramming;
using MindFusion.Drawing;


namespace GTWave.IconNodes
{
	public class IconNode : DiagramNode
	{
		static IconNode()
		{
			defaultIcon = new Bitmap(48, 48);

			Graphics graphics = Graphics.FromImage(defaultIcon);
			Font font = new Font("Arial", 48, FontStyle.Bold, GraphicsUnit.Pixel);

			graphics.FillRectangle(Brushes.Transparent, 0, 0, 48, 48);
			graphics.DrawString("?", font, Brushes.Black, 0, 0);
			
			font.Dispose();
			graphics.Dispose();
		}

		public IconNode(Diagram diagram) : base(diagram)
		{
			icon = defaultIcon;
			label = "Label";

			format = new StringFormat();
			format.Alignment = StringAlignment.Center;
			format.LineAlignment = StringAlignment.Center;

			Bounds = new RectangleF(Bounds.Location, CalculateSize());
		}


		public override void DrawLocal(IGraphics graphics, RenderOptions options)
		{
			RectangleF iconSizePixels = new RectangleF(0, 0, icon.Width, icon.Height);
			var imageSize = MeasureUnit.Pixel.Convert(iconSizePixels, MeasureUnit, null);

			RectangleF localBounds = GetLocalBounds();

			// Draw the icon center at the top
			graphics.DrawImage(icon,
				localBounds.X + localBounds.Width / 2 - imageSize.Width / 2, localBounds.Y);

			// Draw the label at the bottom
			RectangleF labelBounds = RectangleF.FromLTRB(
				localBounds.X, localBounds.Y + imageSize.Height, localBounds.Right, localBounds.Bottom);
			
			graphics.DrawString(label,
				EffectiveFont, Brushes.Black, labelBounds, format);
		}

		public override void DrawShadowLocal(IGraphics graphics, RenderOptions options)
		{
		}

		private SizeF CalculateSize()
		{
			Bitmap tempImage = new Bitmap(1, 1);
			Graphics graphics = Graphics.FromImage(tempImage);
			IGraphics measureGraphics = new GdiGraphics(graphics);

			Parent.MeasureUnit.ApplyTo(measureGraphics);
			Rectangle iconSizePixels = new Rectangle(0, 0, icon.Width, icon.Height);
			RectangleF imageSize = MindFusion.Utilities.DeviceToDoc(
				measureGraphics, iconSizePixels);

			measureGraphics.Dispose();
			tempImage.Dispose();

			SizeF textSize = Parent.MeasureString(label, EffectiveFont, int.MaxValue, format);

			return new SizeF(
				Math.Max(imageSize.Width, textSize.Width),
				imageSize.Height + textSize.Height);
		}

		protected override void UpdateCreate(PointF current)
		{
			base.UpdateCreate(current);
			Bounds = new RectangleF(current, CalculateSize());
		}

		protected override void SaveTo(System.IO.BinaryWriter writer, PersistContext ctx)
		{
			base.SaveTo(writer, ctx);

			// Save the label using the standard .NET BinaryWriter
			writer.Write(label);

			// Save the image using the MindFusion.Diagramming built-in image saving code,
			// which stores the contents of shared images only once.
			ctx.SaveImage(icon);
		}

		protected override void LoadFrom(System.IO.BinaryReader reader, PersistContext ctx)
		{
			base.LoadFrom(reader, ctx);

			label = reader.ReadString();
			icon = ctx.LoadImage();
		}


		public Image Icon
		{
			get { return icon; }
			set
			{
				icon = value;
				Bounds = new RectangleF(Bounds.Location, CalculateSize());
			}
		}

		public string Label
		{
			get { return label; }
			set
			{
				label = value;
				Bounds = new RectangleF(Bounds.Location, CalculateSize());
			}
		}


		private Image icon;
		private string label;
		private StringFormat format;

		static private Image defaultIcon;
	}
}
