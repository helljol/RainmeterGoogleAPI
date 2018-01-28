using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace RainGoo
{
    public class GMessage : IComparable<GMessage>
    {
        private String id;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        private String subject;

        public String Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        private String sender;

        public String Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        private String snipet;

        public String Snipet
        {
            get { return snipet; }
            set { snipet = value; }
        }
        private String link;

        public String Link
        {
            get { return link; }
            set { link = value; }
        }

        private DateTime emailDate;

        public DateTime EmailDate
        {
            get { return emailDate; }
            set { emailDate = value; }
        }

        public int CompareTo(GMessage other)
        {
            int c = this.emailDate.CompareTo(other.emailDate);

            if (c == 0)
                c = this.Subject.CompareTo(other.Subject);

            return c;
        }
    }
}
