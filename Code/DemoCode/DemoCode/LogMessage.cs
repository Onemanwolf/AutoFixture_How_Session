using System;

namespace DemoCode
{
    public class LogMessage
    {
        public Guid Id { get; set; }

        public MessageType MessageType {get; set;}
        public int Year { get; set; }
        public string message { get; set; }
        
    }
}