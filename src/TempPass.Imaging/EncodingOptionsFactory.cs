using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.OneD;

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
