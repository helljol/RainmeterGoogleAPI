using System;
using System.Collections.Generic;
using System.Text;

namespace RainGoo
{
    public class GCal
    {
        private String id;
        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        private String title;
        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        private String link;
        public String Link
        {
            get { return link; }
            set { link = value; }
        }

        private String colorId;
        public String ColorId
        {
            get { return colorId; }
            set { colorId = value; }
        }

        public override String ToString()
        {
            return this.Title;
        }
    }
}
