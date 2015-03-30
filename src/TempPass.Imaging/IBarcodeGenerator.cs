using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempPass.Imaging
{
    public interface IBarcodeGenerator<out TImageType>
    {
        string Encode(IEnumerable<string> values);
        IEnumerable<string> Decode(string data);
        TImageType GenerateBarcodeImage(string data);
    }
}
