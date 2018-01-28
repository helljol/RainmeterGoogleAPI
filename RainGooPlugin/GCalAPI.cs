using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Xml.XPath;
using System.Xml;
using Google.Apis.Calendar.v3;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Services;
using Google.Apis.Calendar.v3.Data;
using System.Globalization;

namespace RainGoo
{
    public class GCalAPI
    {
        private String clientId;
        private String clientSecret;
        private String userName;
        private CalendarService cs;
        private Colors colors;

        public static int STAT_ADDED = 0;
        public static int STAT_UPDATED = 1;
        public static int STAT_DELETED = 2;


        private static int DEFAULT_MAX_RESULTS = 500;



        public GCalAPI(String clientId, String clientSecret,  String userName)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            
            this.userName = userName;
            cs = new GoogleService(clientId, clientSecret,  userName).GetCalendarService();
            colors = cs.Colors.Get().Execute();
        }



        private GCal Convert(CalendarListEntry c)
        {
            if (c == null)
                return null;

            GCal gcal = new GCal();

            gcal.Id = c.Id;
            gcal.Title = c.Summary;
            gcal.Link = "";
            gcal.ColorId = c.ColorId;
            return gcal;
        }


        private GCalEvent Convert(Event e, GCal gcal)
        {
            if (e == null)
                return null;
            
            GCalEvent item = new GCalEvent();
            
            item.Id = e.Id;
            item.Title = e.Summary;

            ColorDefinition cdefCal = new ColorDefinition();
            bool colorCalFound = colors.Calendar.TryGetValue(gcal.ColorId, out cdefCal);
            if (colorCalFound)
            {
                item.HexaColorCal = cdefCal.Background.Replace("#", "");
            }

            item.HexaColor = "000000";
            if (e.ColorId != null)
            {
                ColorDefinition cdef = new ColorDefinition();
                bool colorFound = colors.Event__.TryGetValue(e.ColorId, out cdef);
                if (colorFound)
                {
                    item.HexaColor = cdef.Background.Replace("#","");
                }
            }
            else
            {
                ColorDefinition cdef = new ColorDefinition();
                bool colorFound = colors.Calendar.TryGetValue(gcal.ColorId, out cdef);
                if (colorFound)
                {
                    item.HexaColor = item.HexaColorCal;
                }

            }

            
            if (e.Start.DateTime != null)
            {
                item.IsAllDay = false;
                item.Start = e.Start.DateTime.Value;
                item.End = e.End.DateTime.Value;
            }
            else
            {
                item.IsAllDay = true;

                // All day event if startTime is yyyy-MM-dd
                item.Start = DateTime.ParseExact(e.Start.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                item.End = DateTime.ParseExact(e.End.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }

            item.Link = e.HtmlLink;
            item.IsRecurring = (!String.IsNullOrEmpty(e.RecurringEventId));

            return item;
        }




        /**
	     * get calendars events
	     * 
	     * @return
	     */
        public List<GCal> GetCalendars()
        {
            List<GCal> calendars = new List<GCal>();

            
            CalendarList list = cs.CalendarList.List().Execute();
            foreach (CalendarListEntry o in list.Items)
            {
                calendars.Add(Convert(o));
            } 
            
            return calendars;
        }



        /**
	     * get calendars event for one calendar ID
	     * 
	     * @param calIds
	     * @return
	     */
        public List<GCal> GetCalendars(params String[] calIds)
        {
            List<GCal> allCalendars = GetCalendars();
            List<GCal> calendars = new List<GCal>();

            foreach (GCal cal in allCalendars)
            {
                foreach (String calId in calIds)
                {
                    if (calId.Equals(cal.Id))
                        calendars.Add(cal);
                }
            }

            return calendars;
        }


        public GCal GetCalendar(String calId)
        {
            List<GCal> allCalendars = GetCalendars(calId);
            
            if (allCalendars != null && allCalendars.Count > 0)
                return allCalendars[0];

            return null;
        }






        /**
         * filter events
         * 
         * @param calId
         * @param startMin
         * @param updatedMin
         * @param maxResults
         * @return
         */
        public List<GCalEvent> GetEvents(String calId, DateTime? startDate, DateTime? maxEndDate, int maxResults)
        {
            List<GCalEvent> events = new List<GCalEvent>();

            try
            {
                
                GCal gcal = GetCalendar(calId);
                
                if (maxResults < 0)
                    maxResults = DEFAULT_MAX_RESULTS;

                EventsResource.ListRequest request = cs.Events.List(calId);
                request.MaxResults = maxResults;

                
                
             if (startDate != null)
                {
                    request.TimeMin = startDate;
                }

                request.TimeMax = maxEndDate;

                request.OrderBy = Google.Apis.Calendar.v3.EventsResource.ListRequest.OrderByEnum.StartTime;
                request.SingleEvents = true;
                request.ShowDeleted = false;

                Events gevents = request.Execute();

                foreach (Event e in gevents.Items)
                {
                    GCalEvent g = Convert(e,gcal);
                    g.Calendar = gcal;
                    
                    events.Add(g);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return events;
        }
    }
}
