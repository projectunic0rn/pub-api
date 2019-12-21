using System.Collections.Generic;

namespace Mailer.DTOs
{
    // EmailMessage is the object Mailer receives from
    // the message broker.
    public class EmailMessage
    {
        public EmailMessage()
        {
            ToAddresses = new List<EmailAddress>();
            FromAddresses = new List<EmailAddress>();
        }

        public List<EmailAddress> ToAddresses { get; set; }
        public List<EmailAddress> FromAddresses { get; set; }
        public string Subject { get; set; }
        public List<MailContent> Content { get; set; }
    }

    public class EmailAddress
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    // type is the MIME type of the email message 
    // either text/plain or text/html
    // value is the contents of the email message
    // text for plain text email or html for html email
    public class MailContent
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}