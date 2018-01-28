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
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using System.Net.Http;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Services;

using System.Globalization;


namespace RainGoo
{
    public class GoogleService
    {
        private String clientId;
        private String clientSecret;
        private String appName;
        private String userName;
        private UserCredential credential;
        private List<Message> Messages = new List<Message>();

        public GoogleService(String clientId, String clientSecret, String userName)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.appName = "johell Rainmeter RainGooendar plugin";
            this.userName = userName;

            this.credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }, new[] { GmailService.Scope.GmailReadonly, CalendarService.Scope.Calendar }, userName, CancellationToken.None).Result;

        }


        public GmailService GetGmailService()
        {

            GmailService service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = appName,

            });

            return service;

        }


        public CalendarService GetCalendarService()
        {

            CalendarService service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = appName
            });


            return service;
        }
    }
}
