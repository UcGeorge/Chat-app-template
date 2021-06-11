using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTemplate.Models
{
    class TextMessage
    {
        public string text;
        public string sender;
        public DateTime dateAdded;

        public TextMessage(string text, string sender)
        {
            dateAdded = DateTime.Now;
            this.text = text;
            this.sender = sender;
        }
    }
}
