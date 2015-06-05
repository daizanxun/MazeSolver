using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    interface IImageConvertor
    {
        Stream ConvertTo(Stream stream, ImageFormat format);
    }

    class ImageConvertor : IImageConvertor
    {

    }
}
