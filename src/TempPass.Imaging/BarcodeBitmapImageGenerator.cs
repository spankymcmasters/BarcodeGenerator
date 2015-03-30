using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TempPass.Imaging
{
    public class BarcodeBitmapImageGenerator : IImageGenerator<Bitmap>
    {
        private IBarcodeGenerator<Bitmap> _barcodeGenerator;

        public BarcodeBitmapImageGenerator(IBarcodeGenerator<Bitmap> barcodeGenerator)
        {
            Contract.Requires(null != barcodeGenerator);

            _barcodeGenerator = barcodeGenerator;
        }

        public Bitmap GenerateImage(IEnumerable<string> data)
        {
            var stringData = _barcodeGenerator.Encode(data);
            return _barcodeGenerator.GenerateBarcodeImage(stringData);
        }
    }
}
