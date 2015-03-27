using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempPass.Imaging
{
    public interface IImageGenerator<T>
    {
        T GenerateImage(byte[] data);
    }
}
