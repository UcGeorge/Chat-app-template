using ChatAppTemplate.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace ChatAppTemplate.Templates
{
    abstract class TemplateClient
    {
        protected TcpClient myclient { get; }
        public int port_Number { get; }
        public string serverAddress { get; }
        public IPEndPoint localEP { get; }
        public AddressFamily family { get; }
        public abstract string clientName { get; }
        protected IQueryable<string> contactList { get; set; }

        protected abstract void OnError();
        protected abstract void OnFatalError();

        public TemplateClient(IPEndPoint localEP)
        {
            try
            {
                myclient = new TcpClient(localEP);
            }
            catch (Exception) { OnFatalError(); }
        }
        public TemplateClient(AddressFamily family)
        {
            try
            {
                myclient = new TcpClient(family);
            }
            catch (Exception) { OnFatalError(); }
        }
        public TemplateClient(string hostname, int port)
        {
            serverAddress = hostname;
            port_Number = port;
            try
            {
                myclient = new TcpClient(hostname, port);
            }
            catch (Exception) { OnFatalError(); }
        }
        public TemplateClient() { }

        public abstract void SendMessage(String receiver, String message);
        public abstract void SendMessage(String message);

        public abstract TextMessage ReceiveTextMessage();
        public abstract FileMessage ReceiveFileMessage();

        public virtual void AddContact(string contactName)
        {
            contactList.Append(contactName);
        }
    }
}
