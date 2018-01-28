using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Xml.XPath;
using System.Xml;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using System.Net.Http;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Services;
using Google.Apis.Calendar.v3.Data;
using System.Globalization;


namespace RainGoo
{
    public class GmailAPI
    {
        private String clientId;
        private String clientSecret;
        private String userName;
        private GmailService gs;
        private List<Message> Messages = new List<Message>();

        public static int STAT_ADDED = 0;
        public static int STAT_UPDATED = 1;
        public static int STAT_DELETED = 2;
        

        public GmailAPI(String clientId, String clientSecret,  String userName)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
          
            this.userName = userName;
            gs = new GoogleService(clientId, clientSecret,  userName).GetGmailService();
        }




        /// <summary>
        /// List all Messages of the user's mailbox matching the query.
        /// </summary>
        /// <param name="service">Gmail API service instance.</param>
        /// <param name="userId">User's email address. The special value "me"
        /// can be used to indicate the authenticated user.</param>
        /// <param name="query">String used to filter Messages returned.</param>
        private void ListMessages(String query)
        {
            
            UsersResource.MessagesResource.ListRequest request = gs.Users.Messages.List("me");
            request.Q = query;

            do
            {
                try
                {
                    ListMessagesResponse response = request.Execute();
                    Messages.AddRange(response.Messages);
                    request.PageToken = response.NextPageToken;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            } while (!String.IsNullOrEmpty(request.PageToken));

            
        }

        public List<GMessage> getMessages(string query)
        {
            ListMessages(query);
            List<GMessage> result = new List<GMessage>();
            for (int i = 0; i < Messages.Count; i++)
            {

                UsersResource.MessagesResource.GetRequest request = gs.Users.Messages.Get(this.userName, Messages[i].Id);
                request.Format = UsersResource.MessagesResource.GetRequest.FormatEnum.Metadata;

                Message m = request.Execute();
                GMessage mess = new GMessage();
                
                mess.Snipet = WebUtility.HtmlDecode(m.Snippet);
                mess.Link = "https://mail.google.com/mail/#inbox/" + m.Id;
                mess.Id = m.Id;
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                mess.EmailDate = start.AddMilliseconds(m.InternalDate.GetValueOrDefault()).ToLocalTime();
                bool receivedFound = false;
                //loop on header extracting data
                for (int j = 0; j < m.Payload.Headers.Count; j++)
                {
                    if (m.Payload.Headers[j].Name.ToLower() == "from")
                    {
                        int size = m.Payload.Headers[j].Value.IndexOf("<");
                        if (size  <= 0)
                        {
                            size = m.Payload.Headers[j].Value.IndexOf("@");
                        }
                        if (size < 0)
                        {
                            size = m.Payload.Headers[j].Value.Length;
                        }
                        mess.Sender = m.Payload.Headers[j].Value.Substring(0, size).Replace("\"","").Replace("<","").Trim();
                    }
                    else if (m.Payload.Headers[j].Name.ToLower() == "subject")
                    {
                        mess.Subject = m.Payload.Headers[j].Value;
                    }
                    else if (!receivedFound &&  m.Payload.Headers[j].Name.ToLower() == "received" )
                    {

                        receivedFound = true;
                        try
                        {
                           string[] splitedReceived= m.Payload.Headers[j].Value.Split(';');
                            CultureInfo provider = CultureInfo.InvariantCulture;
                            //Tue, 12 Sep 2017 04:03:21 - 0700(PDT)
                            DateTime receivedDate = new DateTime();
                            bool parseOk = DateTime.TryParseExact(splitedReceived[splitedReceived.Length - 1].Substring(0, splitedReceived[splitedReceived.Length - 1].IndexOf("(")).Trim(), "ddd, dd MMM yyyy HH:mm:ss K", provider,DateTimeStyles.AdjustToUniversal, out receivedDate);
                            if (parseOk)
                            {
                                mess.EmailDate = receivedDate.ToLocalTime();
                                
                            }
                            
                        } catch { }
                       
                    }
                }
                
                
                        result.Add(mess);
                
            }
            return result;

        }

       

    
}
}
