using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryMessageEncoding_Test
{
    public static class GlobalConstant
    {
        // max number of headers in the message
        public const int MaxHeaders = 63;
        // payload length (max 256 KiB)
        public const int PayLoadLengthInBytes = 4;
        //  header name and value length
        public const int HeaderNameLengthInBytes = 2;
    }
}
