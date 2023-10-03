using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryMessageEncoding_Test
{
    public class Message
    {
        public Dictionary<string, string> headers;
        public byte[] payload;
    }
}
