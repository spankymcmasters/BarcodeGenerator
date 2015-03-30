using System;
using System.Collections.Generic;

using ZXing;
using ZXing.Common;
using ZXing.Datamatrix;
using ZXing.OneD;
using ZXing.QrCode;

namespace TempPass.Imaging
{
    internal class EncodingOptionsFactory
    {
        private static IDictionary<BarcodeFormat, Func<EncodingOptions>> _encodingOptionsMap;

        static EncodingOptionsFactory()
        {
            _encodingOptionsMap = new Dictionary<BarcodeFormat, Func<EncodingOptions>>()
                                  {
                                      {
                                          BarcodeFormat.CODE_128, () => new Code128EncodingOptions()
                                      },
                                      {
                                          BarcodeFormat.QR_CODE, () => new QrCodeEncodingOptions()
                                      },
                                      {
                                          BarcodeFormat.DATA_MATRIX, () => new DatamatrixEncodingOptions()
                                      }
                                  };

        }

        public EncodingOptions GetEncodingOptions(BarcodeFormat barcodeFormat)
        {
            var func =  _encodingOptionsMap[barcodeFormat];
            return func.Invoke();
        }
    }
}
