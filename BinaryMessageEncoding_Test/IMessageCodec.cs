using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryMessageEncoding_Test
{
    public interface IMessageCodec
    {
        byte[] Encode(Message message);
        Message Decode(byte[] data);
    }
}
