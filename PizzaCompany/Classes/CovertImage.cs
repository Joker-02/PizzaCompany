using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaCompany.Classes
{
    public static class CovertImage
    {
        public static byte[] CovertImagetoByte(Image image)
        {
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, System.Drawing.Imaging.ImageFormat.Png);
                return m.ToArray();
            }
        }
        public static Image convertBytetoImage(byte[] data)
        {
            using (MemoryStream m = new MemoryStream(data))
            {
                return Image.FromStream(m);
            }
        }
    }
}
