// See https://aka.ms/new-console-template for more information
using BinaryMessageEncoding_Test;
using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        // Test encoding using simple example
        var message = new Message
        {
            headers = new Dictionary<string, string>
            {
                { "TestHeaders1", "TestValue1" },
                { "TestHeaders2", "TestValue2" },
                { "TestHeaders3", "TestValue3" }
            },
            payload = Encoding.ASCII.GetBytes("Payload data.")
        };

        // Create a MessageCodec instance
        var messageCodec = new MessageCodec();

        // Encode the message to a byte array
        byte[] encodedData = messageCodec.Encode(message);

        // Decode the byte array back to a Message
        Message decodedMessage = messageCodec.Decode(encodedData);

        // Display both messages
        Console.WriteLine("Original Message:");
        Helper.PrintMessage(message);

        Console.WriteLine("\n Decoded Message:");
        Helper.PrintMessage(decodedMessage);

        bool messagesMatch = Helper.AreMessagesEqual(message, decodedMessage);
        Console.WriteLine($"\nOriginal and Decoded Messages Matched: {messagesMatch}");

        Console.ReadLine();
    }
    
}