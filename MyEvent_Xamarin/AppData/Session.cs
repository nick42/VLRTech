using System;
using System.Collections.Generic;

namespace AppData
{
    public class Session
    {
        public string m_sTitle { get; set; }
        public string m_sDescription { get; set; }

		public List<EventRelatedPerson> m_oPresenterList { get; set; }

		public Session()
        {
        }
    }
}

