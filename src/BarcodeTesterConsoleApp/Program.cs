using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using TempPass.Imaging;
using ZXing;

namespace BarcodeTesterConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            char separator = '|';

            try
            {
                var id = 1;
                var name = "Dennis Fryzel";
                var date = DateTime.Now.ToShortDateString();

                var barcodeGenerator = new TestBarcodeBitmapGenerator(BarcodeFormat.DATA_MATRIX);
                var imageGenerator = new BarcodeBitmapImageGenerator(barcodeGenerator);
                var image = imageGenerator.GenerateImage(new string[] { id.ToString(), name, date });

                image.Save(".\\TestBarcode.png");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Debug.WriteLine(ex);
            }

            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }
}
