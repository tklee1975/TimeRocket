using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{
    // SouvenirData is the data storing the photo information 
	public class TimeEventData : JSONData {
		public int year = 0;
		public int endYear = 0;
		public bool isRange = false;
		public bool enable = false;
        public string eventName = "";
		
		public override void ParseJSONData(Dictionary<string, object> jsonDict) {
			year = JSONHelper.GetInt (jsonDict, "year", 0);
            endYear = JSONHelper.GetInt (jsonDict, "useIt", 0);
			eventName = JSONHelper.GetString (jsonDict, "eventName", "");
			
            if(eventName == "na") {
                eventName = "";
            }
			eventName.Trim();
			enable = endYear >= 0;
			isRange = endYear > 0;

		}

		public override void DefineJSON (Dictionary<string, object> outDict)
		{
			// This is ReadOnly Game Data. no need to implement DefineJSON 
		}

		public override string ToString ()
		{
			return "year=" + year + " end=" + endYear + " enable=" + enable + " eventName=" + eventName;
		}
	}
}