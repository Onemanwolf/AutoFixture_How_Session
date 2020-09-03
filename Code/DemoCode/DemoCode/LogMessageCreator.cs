using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode
{
    public class LogMessageCreator
    {
        public LogMessage Create(string message, DateTime when, Guid Id, MessageType type)
        {
            return new LogMessage
            {
                Id = Id,
                MessageType = type,
                Year = when.Year,
                message = message
            };
        }
    }
}
