using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Rainmeter;
using RainGoo;
using System.Text;
using System.IO;
using System.Threading.Tasks;



namespace RainGooPlugin
{
    internal class Measure
    {
        internal virtual void Reload(Rainmeter.API api, ref double maxValue)
        {
            
        }

        internal virtual double Update()
        {
            return 0.0;
        }

        internal virtual String GetString()
        {
            return "";
        }
    }


    internal class ParentMeasure : Measure
    {
        public static bool firstgmailInit = true;
        public static string PARAM_CAL = "Cal";
        public static string PARAM_MAX = "Max";
        public static string PARAM_REFRESH_CAL = "RefreshCal";
        public static string PARAM_REFRESH_MAIL = "RefreshMail";
        public static string PARAM_LIMIT2XDAYS = "Limit2Xdays";
        public static string PARAM_TODAY_FORMAT = "TodayDateFormat";
        public static string PARAM_WEEK_DATE_FORMAT = "WeekDateFormat";
        public static string PARAM_DATE_FORMAT = "DateFormat";
        public static string PARAM_INC_PATH = "IncludePath";
        
        public static string PARAM_GOOGLE_CLIENT_ID = "GoogleClientId";
        public static string PARAM_GOOGLE_CLIENT_SECRET = "GoogleClientSecret";
        public static string PARAM_GOOGLE_APP_NAME = "GoogleAppName";
        public static string PARAM_GOOGLE_USER_NAME = "GoogleUserName";
        public static bool gmailUpdateInProgress;
        public static bool calendarUpdateInProgress;
        static Task tgmail;
        static Task tcal;

        internal string Name;
        internal IntPtr Skin;
        
        static int DEFAULT_MAX = 8;
        static int DEFAULT_LIMITXDAYS = 365;
        static long MIN_INTERVAL = 30000L;
        static long MIN_INTERVALGMAIL = 10000L;


        internal List<string> calUrls = new List<string>();
        internal int max = DEFAULT_MAX;
        internal int Limit2Xdays = DEFAULT_LIMITXDAYS;
        internal int maxGmail = DEFAULT_MAX;
        internal long lastUpdate = 0;
        internal long lastUpdategmail = 0;
        internal long lastCheckOfIncFile = 0;
        internal List<GCalEvent> lastEvents = new List<GCalEvent>();
        internal List<GMessage> lastMessages = null;
        internal String weekDateFormat;
        internal String dateFormat;
        internal String todayDateFormat;

        internal String googleClientId;
        internal String googleClientSecret;
        internal String googleAppName;
        internal String googleUserName;
        internal string gmailPath;
        internal string calendarPath;
        internal ParentMeasure()
        {
        }

        internal override void Reload(Rainmeter.API api, ref double maxValue)
        {
            base.Reload(api, ref maxValue);

            Name = api.GetMeasureName();
            //API.Log(API.LogType.Notice, "RainGoo.dll : Measure name is  : " + Name);

            googleClientId = api.ReadString(PARAM_GOOGLE_CLIENT_ID, "");
            googleClientSecret = api.ReadString(PARAM_GOOGLE_CLIENT_SECRET, "");
            googleAppName = api.ReadString(PARAM_GOOGLE_APP_NAME, "");
            googleUserName = api.ReadString(PARAM_GOOGLE_USER_NAME, "");

            

            if (Name == "mGcal")
            {
                Skin = api.GetSkin();

                calUrls.Clear();

                int i = 1;
                String tmp = null;

                while (!String.IsNullOrWhiteSpace((tmp = api.ReadString(PARAM_CAL + i, ""))))
                {
                    if (tmp != "#Calendar2#" && tmp != "#Calendar3#")
                    {
                        calUrls.Add(tmp);
                        
                    }
                    i++;
                }

                max = api.ReadInt(PARAM_MAX, DEFAULT_MAX);
                Limit2Xdays = api.ReadInt(PARAM_LIMIT2XDAYS, DEFAULT_LIMITXDAYS);
                MIN_INTERVAL = api.ReadInt(PARAM_REFRESH_CAL, 30)*1000;
                

                todayDateFormat = api.ReadString(PARAM_TODAY_FORMAT, "HH:mm");
                weekDateFormat = api.ReadString(PARAM_WEEK_DATE_FORMAT, "ddd");
                dateFormat = api.ReadString(PARAM_DATE_FORMAT, "ddd dd MMM");



#if DEBUG
                API.Log(API.LogType.Notice, "RainGoo.dll: Calendars : " + calUrls.Count + " - Max results : " + max + " - Limit 2 X days : " + Limit2Xdays);
#endif

                calendarPath = api.ReadPath(PARAM_INC_PATH, "");

                lastUpdate = 0; 
                UpdateEvents();
            }
            else 
            {
                
                Skin = api.GetSkin();
                // Generates include files
                maxGmail = api.ReadInt(PARAM_MAX, DEFAULT_MAX);
                gmailPath = api.ReadPath(PARAM_INC_PATH, "");
#if DEBUG
                API.Log(API.LogType.Notice, "RainGoo.dll: Gmail inc file path :" + gmailPath);
#endif
                lastUpdategmail = 0;
                MIN_INTERVALGMAIL = api.ReadInt(PARAM_REFRESH_MAIL, 10) * 1000;
                UpdateGmail();




            }
        }
        

        internal override double Update()
        {
     
            //API.Log(API.LogType.Notice, "RainGoo.dll : update Measure name is  : " + Name);
            if (Name == "mGcal")
            {


                if (tcal != null && !tcal.IsCompleted || calendarUpdateInProgress == true)
                {
#if DEBUG
                    if (calendarUpdateInProgress)
                    {
                        API.Log(API.LogType.Notice, "calendar task was not completed, return previous result");
                    }
                    else
                    {
                        API.Log(API.LogType.Notice, "calendar task not  yet completed, return previous result");
                    }
#endif
                    calendarUpdateInProgress = false;
                    return lastEvents.Count;
                }
                else
                {

                    tcal = Task.Run(() => UpdateEvents());
#if DEBUG
                    API.Log(API.LogType.Notice, "cal task started");
#endif
                    if (tcal.IsCompleted)
                    {
#if DEBUG
                        API.Log(API.LogType.Notice, "cal task completed");
#endif
                        calendarUpdateInProgress = false;
                    }
                    else
                    {
#if DEBUG
                        API.Log(API.LogType.Notice, "cal task  not completed" + tcal.Status);
#endif
                        calendarUpdateInProgress = true;
                    }
                    return lastEvents.Count;
                }
            }
            else
            {
              
                if (tgmail != null && !tgmail.IsCompleted || gmailUpdateInProgress == true)
                {
#if DEBUG
                    if (gmailUpdateInProgress)
                    {
                        API.Log(API.LogType.Notice, "Gmail task was not completed, return previous result");
                    }
                    else
                    {
                        API.Log(API.LogType.Notice, "Gmail task not  yet completed, return previous result");
                    }
#endif
                    gmailUpdateInProgress = false;
                    return lastMessages.Count;
                }
                else
                {


                    tgmail = Task.Run(() => UpdateGmail());
#if DEBUG
                    API.Log(API.LogType.Notice, "Gmail task started");
#endif
                    //UpdateGmail();
                    int incFileCheck = lastMessages.Count;
                    long now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    if (!String.IsNullOrEmpty(gmailPath) && firstgmailInit == false && ((now - lastCheckOfIncFile) > (MIN_INTERVALGMAIL * 6)))
                    {
#if DEBUG
                        API.Log(API.LogType.Notice, "Checking for template file VS Message Consistency");
#endif
                        lastCheckOfIncFile = now;
                        incFileCheck = Tools.readExistingFileCount(Path.Combine(gmailPath, "Measures.inc"));

                    }
#if DEBUG
                    API.Log(API.LogType.Notice, "now - lastCheckOfIncFileI" + (now - lastCheckOfIncFile));
#endif
                    if (firstgmailInit == true || incFileCheck != lastMessages.Count)
                    {
#if DEBUG
                        API.Log(API.LogType.Notice, "Gmail first init/bad template file");
#endif
                        firstgmailInit = false;
                        lastUpdategmail = 0;
                        lastCheckOfIncFile = now;
                        return lastMessages.Count - 0.5;
                    }
                    else
                    {
                        if (tgmail.IsCompleted)
                        {
#if DEBUG
                            API.Log(API.LogType.Notice, "Gmail task completed");
#endif
                            gmailUpdateInProgress = false;
                        }
                        else
                        {
#if DEBUG
                            API.Log(API.LogType.Notice, "Gmail task  not completed"+ tgmail.Status);
#endif
                            gmailUpdateInProgress = true;
                        }
                        return lastMessages.Count;

                    }
                }

                
            }
        }
       
        internal  Boolean UpdateGmail()
        {
            
            try
            {
                long now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

                
                if (now - lastUpdategmail < MIN_INTERVALGMAIL)
                {
                    //API.Log(API.LogType.Notice, "RainGoo.dll: Update interval too short ! ("+ MIN_INTERVALGMAIL + ")");
                    return false;
                }

                List<GMessage> mess = null;
                if (googleClientId == null || googleClientId == "" || googleClientId == "#GoogleAccountID#" || googleClientSecret == null || googleClientSecret == "" || googleClientSecret == "#GoogleAccountSecret#" || googleUserName == null || googleUserName == "" || googleUserName == "#GmailUserName#")
                {
                    mess = new List<GMessage>();
                    if (googleClientId == null || googleClientId == "" || googleClientId == "#GoogleAccountID#" || googleClientSecret == null || googleClientSecret == "" || googleClientSecret == "#GoogleAccountSecret#")
                    {
                        GMessage fakeMess = new GMessage();
                        fakeMess.EmailDate = DateTime.Now;
                        fakeMess.Link = "https://console.cloud.google.com";
                        fakeMess.Subject = "No google ID/Secret provided";
                        fakeMess.Snipet = "Click here to create one and then please use config button to setup your google account.";
                        fakeMess.Id = "fake123456";
                        fakeMess.Sender = "Google API Setup not done";
                        mess.Add(fakeMess);
                    }
                    if (googleUserName == null || googleUserName == "" || googleUserName == "#GmailUserName#")
                    {
                        GMessage fakeMess = new GMessage();
                        fakeMess.EmailDate = DateTime.Now;
                        fakeMess.Link = "https://gmail.com";
                        fakeMess.Subject = "No Gmail User name provided";
                        fakeMess.Snipet = "Please use config button to setup your Gmail account.";
                        fakeMess.Id = "fake123456b";
                        fakeMess.Sender = "Gmail Setup not done";
                        mess.Add(fakeMess);
                    }


                   


                }
                else
                {
                    
                    GmailAPI gm = new GmailAPI(googleClientId, googleClientSecret, googleUserName);
                    mess = gm.getMessages("IN:INBOX IS:UNREAD");
                    

                }

                int maxMessage = mess.Count;
                if (mess.Count > maxGmail)
                {
                    maxMessage = maxGmail;
                }
                if (lastMessages == null || lastMessages.Count != mess.Count  )
                {

                    if (!String.IsNullOrEmpty(gmailPath))
                    {
                        //API.Log(API.LogType.Notice, "RainGoo.dll: building inc file for " + maxMessage + " lines");
                        Tools.GenerateIncFile(maxMessage
                                , Path.Combine(gmailPath, "TMeasuresGmail.inc")
                                , Path.Combine(gmailPath, "Measures.inc"));

                        Tools.GenerateIncFile(maxMessage
                            , Path.Combine(gmailPath, "TMetersGmail.inc")
                            , Path.Combine(gmailPath, "Meters.inc"));
                    }
                }

                
                

                    lastMessages = mess;
                    lastUpdategmail = now;
                
               
                return true;
            }
            catch (Exception e)
            {
                API.Log(API.LogType.Error, "RainGoo.dll: Cannot read messages : " + e.Message);
            }

            return false;
        }
        internal Boolean UpdateEvents()
        {

            try
            {
                long now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

                
                if (now - lastUpdate < MIN_INTERVAL)
                {
#if DEBUG
                    API.Log(API.LogType.Notice, "RainGoo.dll: Calendar update interval too short !");
#endif
                    return false;
                }
                List<GCalEvent> events = null;
                if (googleClientId == null || googleClientId == "" || googleClientId == "#GoogleAccountID#" || googleClientSecret == null || googleClientSecret == "" || googleClientSecret == "#GoogleAccountSecret#" || googleUserName == null || googleUserName == "" || googleUserName == "#GmailUserName#" || calUrls.Count ==0 || calUrls[0] == null || calUrls[0] == "" || calUrls[0] =="#Calendar1#" )
                {
                    events = new List<GCalEvent>();
                    if (googleClientId == null || googleClientId == "" || googleClientId == "#GoogleAccountID#" || googleClientSecret == null || googleClientSecret == "" || googleClientSecret == "#GoogleAccountSecret#")
                    {
                        GCalEvent fakeEvent = new GCalEvent();
                        fakeEvent.Start = DateTime.Now;
                        fakeEvent.IsAllDay = true;
                        fakeEvent.End = DateTime.Now;
                        fakeEvent.Link = "https://console.cloud.google.com";
                        fakeEvent.Title = "No google ID/Secret provided";
                        fakeEvent.Id = "fake123456";
                        fakeEvent.HexaColor = "000000";
                        fakeEvent.HexaColorCal = "000000";
                        
                        
                        events.Add(fakeEvent);
                    }

                    if (googleUserName == null || googleUserName == "" || googleUserName == "#GmailUserName#")
                    {
                        GCalEvent fakeEvent = new GCalEvent();
                        fakeEvent.Start = DateTime.Now;
                        fakeEvent.IsAllDay = true;
                        fakeEvent.End = DateTime.Now;
                        fakeEvent.Link = "https://console.cloud.google.com";
                        fakeEvent.Title = "No Calendar user name provided";
                        fakeEvent.Id = "fake123456";
                        fakeEvent.HexaColor = "000000";
                        fakeEvent.HexaColorCal = "000000";
                        
                        events.Add(fakeEvent);
                        
                    }

                    if (calUrls.Count == 0 || calUrls[0] == null || calUrls[0] == "" || calUrls[0] == "#Calendar1#" )
                    {
                        GCalEvent fakeEvent = new GCalEvent();
                        fakeEvent.Start = DateTime.Now;
                        fakeEvent.IsAllDay = true;
                        fakeEvent.End = DateTime.Now;
                        fakeEvent.Link = "https://console.cloud.google.com";
                        fakeEvent.Title = "No Calendar provided";
                        fakeEvent.Id = "fake123456";
                        fakeEvent.HexaColor = "000000";
                        fakeEvent.HexaColorCal = "000000";
                        events.Add(fakeEvent);

                    }

                    

                }
                else
                {
                    
                    events = new List<GCalEvent>();
                    GCalAPI gcal = new GCalAPI(googleClientId, googleClientSecret, googleUserName);
#if DEBUG
                    API.Log(API.LogType.Notice, "RainGoo.dll: About to read events...");
#endif

                    for (int i = 0; i < calUrls.Count; i++)
                    {
                        String calUrl = calUrls[i];
#if DEBUG
                        API.Log(API.LogType.Notice, "RainGoo.dll: Retrieving calendar [" + calUrl + "]");
#endif
                        List<GCalEvent> e = gcal.GetEvents(calUrl, DateTime.Now, DateTime.Now.AddDays(Limit2Xdays), max);


                        foreach (GCalEvent ge in e)
                        {
                            ge.Data.Add("CalId", (i + 1).ToString());
                        }

                        events.AddRange(e);
                    }



                    events.Sort();
                }
                
                if (events.Count > max)
                {
                    events.RemoveRange(max, (events.Count - max));
                }
                // Generates include files
                
                if (!String.IsNullOrEmpty(calendarPath))
                {
                    Tools.GenerateIncFile(events.Count
                            , Path.Combine(calendarPath, "TMeasures.inc")
                            , Path.Combine(calendarPath, "Measures.inc"));

                    Tools.GenerateIncFile(events.Count
                        , Path.Combine(calendarPath, "TMeters.inc")
                        , Path.Combine(calendarPath, "Meters.inc"));
                }
                lastUpdate = now;
                lastEvents = events;
              
                return true;
            }
            catch (Exception e)
            {
                API.Log(API.LogType.Error, "RainGoo.dll: Cannot update events : " + e.Message);
            }
            
            return false;
        }


        internal override String GetString()
        {
            if (Name.ToLower() == "mgmail")
            {
                
                
               return lastMessages.Count.ToString();
                
            }
            else
            {
                return lastEvents.Count.ToString();
            }
        }
    }


    

    internal class ChildMeasure : Measure
    {
        public static String PARAM_PARENT_NAME = "ParentName";
        public static String PARAM_PROPERTY = "Property";
        public static String PARAM_INDEX = "Index";
        
        
        private bool HasParent = false;
        private uint ParentID;
        private int ndx;
        private String property;
        internal String todayDateFormat;
        internal String weekDateFormat;
        internal String dateFormat;
        

        internal override void Reload(Rainmeter.API api, ref double maxValue)
        {
            base.Reload(api, ref maxValue);

            string parentName = api.ReadString(PARAM_PARENT_NAME, "");
            
            IntPtr skin = api.GetSkin();

            property = api.ReadString(PARAM_PROPERTY, "");
            

            String mesureName = api.GetMeasureName();
            
            if (mesureName.StartsWith(parentName))
            {
                String sndx = mesureName.Substring(parentName.Length);
                if (sndx.IndexOf("_") > 0)
                {
                    if (String.IsNullOrEmpty(property))
                        property = sndx.Substring(sndx.IndexOf("_") + 1);

                    sndx = sndx.Substring(0, sndx.IndexOf("_"));
                }

                ndx = int.Parse(sndx);
            }
            else
            {
                ndx = api.ReadInt(PARAM_INDEX, 1);
            }

            ndx--;


            // Find parent using name AND the skin handle to be sure that it's the right one
            RuntimeTypeHandle parentType = typeof(ParentMeasure).TypeHandle;
            foreach (KeyValuePair<uint, Measure> pair in Plugin.Measures)
            {
                
                if (System.Type.GetTypeHandle(pair.Value).Equals(parentType))
                {
                    ParentMeasure parentMeasure = (ParentMeasure)pair.Value;
                
                    if (parentMeasure.Name.Equals(parentName) &&
                        parentMeasure.Skin.Equals(skin))
                    {
                        
                        HasParent = true;
                        ParentID = pair.Key;

                        todayDateFormat = api.ReadString(ParentMeasure.PARAM_TODAY_FORMAT, parentMeasure.todayDateFormat);
                        weekDateFormat = api.ReadString(ParentMeasure.PARAM_WEEK_DATE_FORMAT, parentMeasure.weekDateFormat);
                        dateFormat = api.ReadString(ParentMeasure.PARAM_DATE_FORMAT, parentMeasure.dateFormat);

                        return;
                    }
                }
            }

            HasParent = false;
            API.Log(API.LogType.Error, "RainGoo.dll: ParentName=" + parentName + " not valid");
        }


        internal override double Update()
        {
            // Retourner 1 ou 0 si la valeur est boolean. Sinon -1.
            Object o = GetValue();
            if (o == null) return -1;

            if (o is Boolean)
            {
                Boolean b = (Boolean) o;
                return (b ? 1 : 0);
            }

            return 0.0;
        }


        internal override String GetString()
        {
            Object o = GetValue();
            return (o != null ? o.ToString() : null);
        }


        internal Object GetValue()
        {
            if (HasParent)
            {
                ParentMeasure parent = (ParentMeasure)Plugin.Measures[ParentID];
                
                double countItem = 0;
                if (parent.Name == "mGcal" && parent.lastEvents != null)
                {
                    countItem = parent.lastEvents.Count;

                }
                else if (parent.lastMessages != null)
                {
                    countItem = parent.lastMessages.Count;
                }
                else
                {
                    return "";
                }

                if (countItem > ndx)
                {
                    try
                    {
                        object value = null;
                        if (parent.Name == "mGcal")
                        {
                            GCalEvent ge = parent.lastEvents[ndx];
                            value = Tools.getObjectProperty(ge, property);
                            if (value == null)
                            {
                                return "";
                            }

                            if (value is DateTime)
                            {
                                DateTime dt = (DateTime)value;

                                if (Tools.IsToday(dt))
                                    return dt.ToString(todayDateFormat);

                                else if (Tools.IsInWeek(dt))
                                    return dt.ToString(weekDateFormat);

                                else
                                    return dt.ToString(dateFormat);
                            }

                            else if (value is Boolean)
                            {
                                return ((Boolean)value) ? "1" : "0"; // See Update
                            }

                            else
                            {
                                return value.ToString();
                            }
                        }
                        else
                        {
                            GMessage gm = parent.lastMessages[ndx];
                            if (this.property == "EmailDate")
                            {
                                return gm.EmailDate.ToShortDateString() + " " + gm.EmailDate.ToShortTimeString();
                              
                            }
                            else
                            {
                             
                                value = Tools.getObjectProperty(gm, property);
                                return value.ToString();
                            }
                                                       
                        }

                       
                    }
                    catch (Exception e)
                    {
                        API.Log(API.LogType.Error, "RainGoo.dll: Exception : " + e.Message);
                    }
                }
            }


            
              //  API.Log(API.LogType.Warning, "RainGoo.dll: Cannot get value with index [" + ndx + "] and property [" + property + "]");
                
            

            return "";
        }
    
    }

    

    public static class Plugin
    {
        internal static Dictionary<uint, Measure> Measures = new Dictionary<uint, Measure>();

        [DllExportAttribute]
        public unsafe static void Initialize(void** data, void* rm)
        {
            uint id = (uint)((void*)*data);
            Rainmeter.API api = new Rainmeter.API((IntPtr)rm);

            string parent = api.ReadString("ParentName", "");
            if (String.IsNullOrEmpty(parent))
            {
                Measures.Add(id, new ParentMeasure());
            }
            else 
            {
                Measures.Add(id, new ChildMeasure());
            }
            
        }

        [DllExportAttribute]
        public unsafe static void Finalize(void* data)
        {
            uint id = (uint)data;
            Measures.Remove(id);
        }

        [DllExportAttribute]
        public unsafe static void Reload(void* data, void* rm, double* maxValue)
        {
            uint id = (uint)data;
            Measures[id].Reload(new Rainmeter.API((IntPtr)rm), ref *maxValue);
        }

        [DllExportAttribute]
        public unsafe static double Update(void* data)
        {
            uint id = (uint)data;
            return Measures[id].Update();
        }

        [DllExportAttribute]
        public unsafe static char* GetString(void* data)
        {
            uint id = (uint)data;
            fixed (char* s = Measures[id].GetString()) return s;
        }
    }
}
