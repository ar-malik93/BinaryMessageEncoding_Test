using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryMessageEncoding_Test
{
    public static class Helper
    {
        public static void PrintMessage(Message message)
        {
            Console.WriteLine("Headers:");
            foreach (var entry in message.headers)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            Console.WriteLine($"Payload Length: {message.payload.Length} bytes");
            Console.WriteLine($"Payload Data: {Encoding.ASCII.GetString(message.payload)}");
        }

        public static bool AreMessagesEqual(Message message1, Message message2)
        {
            if (message1.headers.Count != message2.headers.Count)
                return false;

            foreach (var entry1 in message1.headers)
            {
                if (!message2.headers.TryGetValue(entry1.Key, out var value) || value != entry1.Value)
                    return false;
            }

            if (!ByteArraysEqual(message1.payload, message2.payload))
                return false;

            return true;
        }

        public static bool ByteArraysEqual(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
                return false;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }

            return true;
        }
    }
}
