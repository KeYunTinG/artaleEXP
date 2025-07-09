using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace expTool
{
    public static class PixConverter
    {
        public static Pix ToPix(Bitmap bitmap)
        {
            using (var stream = new MemoryStream())
            {
                // 指定 System.Drawing 的 ImageFormat
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Position = 0;
                return Pix.LoadFromMemory(stream.ToArray());
            }
        }
    }
}
