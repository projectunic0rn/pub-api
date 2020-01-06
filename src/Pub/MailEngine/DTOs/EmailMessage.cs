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
            Content = new List<MailContent>();
        }

        public List<EmailAddress> ToAddresses { get; set; }
        public List<EmailAddress> FromAddresses { get; set; }
        public string Subject { get; set; }
        public List<MailContent> Content { get; set; }
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

    // Type is the MIME type of the email message 
    // either text/plain or text/html
    // value is the contents of the email message
    // text for plain text email or html for html email
    public class MailContent
    {
        public MailContent(string type)
        {
            Type = type;
        }
        
        public MailContent(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public string Type { get; set; }
        public string Value { get; set; }
    }
}