using System.Collections.Generic;

namespace MailEngine.DTOs
{
    // EmailMessage is the object Mailer receives from
    // the message broker.
    public class EmailMessage
    {
        public EmailMessage()
        {
            ToAddresses = new List<EmailAddress>();
            FromAddresses = new List<EmailAddress>();
            MailContent = new Dictionary<string, string>();
        }

        public List<EmailAddress> ToAddresses { get; set; }
        public List<EmailAddress> FromAddresses { get; set; }
        public string Subject { get; set; }
        public Dictionary<string, string> MailContent { get; set; }
    }

    public class EmailAddress
    {
        public EmailAddress(string name, string address)
        {
            Name = name;
            Address = address;
        }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}