using System;
using System.Drawing;

using ZXing;
using ZXing.OneD;
using ZXing.Rendering;


namespace TempPass.Imaging
{
    public class BarcodeBitmapGenerator : IImageGenerator<Bitmap>
    {
        public Bitmap GenerateImage(byte[] data)
        {
            const int width = 100;
            const int height = 50;
            
            Bitmap finalImg = null;
            var content = Convert.ToBase64String(data);
            var writer = new BarcodeWriter
                         {
                             Format = BarcodeFormat.CODE_128,
                             Options = new Code128EncodingOptions() { Height=height,Width=width}
                         };

            var bitMatrix = writer.Encode(content);
            
            using (var barcode = writer.Write(bitMatrix))
            {
                using (var textImg = createTextImage(content, barcode.Height, barcode.Width, Color.White, Color.Black))
                {
                    finalImg = mergeBitmaps(barcode, textImg);
                }
            }

            return finalImg;

        }

        private Bitmap createTextImage(string imageText, int height, int width, Color backgroundColor, Color fontColor)
        {
            const int minHeight = 10;

            var newHeight = height/5;
            newHeight = newHeight < minHeight ? minHeight : newHeight;
            var font = new Font(FontFamily.GenericSansSerif, newHeight, FontStyle.Regular, GraphicsUnit.Pixel);
            var bitmap = new Bitmap(width, newHeight + 1);

            using (var objGraphics = Graphics.FromImage(bitmap))
            {
                using (
                    var stringFormat = new StringFormat()
                                       {
                                           Alignment = StringAlignment.Center,
                                           LineAlignment = StringAlignment.Center
                                       })
                {
                    objGraphics.Clear(backgroundColor);
                    objGraphics.DrawString(imageText, font, new SolidBrush(fontColor), new RectangleF(0, 0,bitmap.Width, bitmap.Height), stringFormat);
                    objGraphics.Flush();
                }
            }

            return bitmap;
        }

        private Bitmap mergeBitmaps(Bitmap image1, Bitmap image2)
        {
            if (image1 == null)
            {
                throw new ArgumentNullException("image1");
            }

            if (image2 == null)
            {
                throw new ArgumentNullException("image2");
            }

            var outputImageWidth = image1.Width > image2.Width ? image1.Width : image2.Width;
            var outputImageHeight = image1.Height + image2.Height + 1;
            var outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (var graphics = Graphics.FromImage(outputImage))
            {
                graphics.DrawImage(image1, new Rectangle(new Point(), image1.Size),
                    new Rectangle(new Point(), image1.Size), GraphicsUnit.Pixel);
                graphics.DrawImage(image2, new Rectangle(new Point(0, image1.Height + 1), image2.Size),
                    new Rectangle(new Point(), image2.Size), GraphicsUnit.Pixel);
            }

            return outputImage;
            
        }
    }
}
