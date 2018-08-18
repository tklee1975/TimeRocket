using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{
    // SouvenirData is the data storing the photo information 
	public class TimeSceneData : JSONData {
		public int startYear = 0;
        public bool isRange = true;
		public string building = "";
		public string subject = "";
        
		public override void ParseJSONData(Dictionary<string, object> jsonDict) {
			startYear = JSONHelper.GetInt (jsonDict, "startYear", 0);
            isRange = JSONHelper.GetInt (jsonDict, "isRange", 1) == 1;
			building = JSONHelper.GetString (jsonDict, "building", "city_01");
			subject = JSONHelper.GetString (jsonDict, "subject", "na");

            if(subject == "na") {
                subject = "";
            }

		}

		public override void DefineJSON (Dictionary<string, object> outDict)
		{
			// This is ReadOnly Game Data. no need to implement DefineJSON 
		}

		public override string ToString ()
		{
			return "startYear=" + startYear + " building=" + building + " isRange=" + isRange;
		}
	}
}