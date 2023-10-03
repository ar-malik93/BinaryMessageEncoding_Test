using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryMessageEncoding_Test
{
    public static class GlobalConstant
    {
        public const int MaxHeaders = 63;
        public const int PayLoadLengthInBytes = 4;
        public const int HeaderNameLengthInBytes = 2;
    }
}
