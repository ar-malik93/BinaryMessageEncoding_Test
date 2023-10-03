using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryMessageEncoding_Test
{
    public class MessageCodec : IMessageCodec
    {
        public byte[] Encode(Message message)
        {
            int headerCount = Math.Min(message.headers.Count, GlobalConstant.MaxHeaders);
            int totalHeaderLength = 0;

            foreach (var entry in message.headers)
            {
                totalHeaderLength += Encoding.ASCII.GetByteCount(entry.Key) + Encoding.ASCII.GetByteCount(entry.Value) + GlobalConstant.PayLoadLengthInBytes;
            }

            int totalLength = GlobalConstant.HeaderNameLengthInBytes + totalHeaderLength + GlobalConstant.PayLoadLengthInBytes + message.payload.Length;

            byte[] encodedMessage = new byte[totalLength];
            int offset = 0;

            BitConverter.GetBytes((ushort)headerCount).CopyTo(encodedMessage, offset);
            offset += GlobalConstant.HeaderNameLengthInBytes;

            foreach (var entry in message.headers)
            {
                byte[] nameBytes = Encoding.ASCII.GetBytes(entry.Key);
                byte[] valueBytes = Encoding.ASCII.GetBytes(entry.Value);

                BitConverter.GetBytes((ushort)nameBytes.Length).CopyTo(encodedMessage, offset);
                offset += GlobalConstant.HeaderNameLengthInBytes;

                BitConverter.GetBytes((ushort)valueBytes.Length).CopyTo(encodedMessage, offset);
                offset += GlobalConstant.HeaderNameLengthInBytes;

                nameBytes.CopyTo(encodedMessage, offset);
                offset += nameBytes.Length;

                valueBytes.CopyTo(encodedMessage, offset);
                offset += valueBytes.Length;
            }

            BitConverter.GetBytes(message.payload.Length).CopyTo(encodedMessage, offset);
            offset += GlobalConstant.PayLoadLengthInBytes;

            message.payload.CopyTo(encodedMessage, offset);

            return encodedMessage;
        }

        public Message Decode(byte[] data)
        {
            int offset = 0;

            ushort headerCount = BitConverter.ToUInt16(data, offset);
            offset += GlobalConstant.HeaderNameLengthInBytes;

            Message message = new Message
            {
                headers = new Dictionary<string, string>(),
            };

            for (int i = 0; i < headerCount; i++)
            {
                ushort nameLength = BitConverter.ToUInt16(data, offset);
                offset += GlobalConstant.HeaderNameLengthInBytes;

                ushort valueLength = BitConverter.ToUInt16(data, offset);
                offset += GlobalConstant.HeaderNameLengthInBytes;

                string headerName = Encoding.ASCII.GetString(data, offset, nameLength);
                offset += nameLength;

                string headerValue = Encoding.ASCII.GetString(data, offset, valueLength);
                offset += valueLength;

                message.headers.Add(headerName, headerValue);
            }

            int payloadLength = BitConverter.ToInt32(data, offset);
            offset += GlobalConstant.PayLoadLengthInBytes;

            message.payload = new byte[payloadLength];
            Array.Copy(data, offset, message.payload, 0, payloadLength);

            return message;
        }
    }
}
