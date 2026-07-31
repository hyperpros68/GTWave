using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FireFly.utils
{
    public class ImageUtil
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        public  Image GetImage(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            stream.Position = 0;
            return (Image.FromStream(stream));
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        public Image ResizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }

        public Image OverWriteShape(Image Shape, Image background, Size Pos)
        {
            Image img = new Bitmap(background);
            PointF ImagePos = new PointF(Pos.Width - (Shape.Width / Shape.HorizontalResolution * img.HorizontalResolution) / 2, Pos.Height - (Shape.Height / Shape.VerticalResolution * img.VerticalResolution) / 2);

            Graphics formGraphics = Graphics.FromImage(img);

            formGraphics.DrawImage(Shape, ImagePos);

            formGraphics.Save();
            formGraphics.Dispose();
            return img;
        }
    }
}
