using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Exceptions
{
    public class ImageException : Exception
    {
        public ImageException()
        {

        }

        public ImageException(string message) : base(message)
        {

        }
    }
}
