using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempPass.Imaging
{
    public interface IBarcodeGenerator<out TImageType>
    {
        string GenerateData(params string[] values);
        TImageType GenerateBarcodeImage(string data);
    }
}
