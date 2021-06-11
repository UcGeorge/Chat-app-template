using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppTemplate.Models
{
    class FileMessage
    {
        public byte[] fileContents;
        public string fileName;
        public string sender;
        public DateTime dateAdded;

        public FileMessage(string fileName, string sender, byte[] fileContents)
        {
            dateAdded = DateTime.Now;
            this.fileName = fileName;
            this.sender = sender;
            this.fileContents = fileContents;
        }
    }
}
