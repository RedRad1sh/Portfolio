using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetApp.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; private set; }
        public string NameOfSender { get; private set; }
        public string Contact { get; private set; }

        public Message(string content, string nameOfSender, string contact, int id)
        {
            Content = content;
            NameOfSender = nameOfSender;
            Contact = contact;
            Id = id;
        }
    }
}
