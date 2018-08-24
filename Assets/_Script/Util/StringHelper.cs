using System.Collections;
using System.Collections.Generic;
using System;

public class StringHelper
{
    public static string JoinInt(string sep, int[] intArray) {
        string[] strArray = new string[intArray.Length];
        for(int i=0; i<intArray.Length; i++) {
            strArray[i] = intArray[i].ToString();
        }

        return string.Join(sep, strArray);
    }

    public static string JoinIntList(string sep, List<int> intList) {
        return JoinInt(sep, intList.ToArray());
    }

    public static string SecondToHHMMSS(double totalSeconds) {
        TimeSpan span = TimeSpan.FromSeconds(totalSeconds);

        return span.TotalHours.ToString("00") 
                + ":" + span.Minutes.ToString("00")
                + ":" + span.Seconds.ToString("00");
    }

    public static string GetFriendlyTime(DateTime time) {
        TimeSpan timeDiff = DateTime.Now - time;
        if(timeDiff.TotalSeconds <= 10) {
            return "Just now";
        }

        if(timeDiff.TotalDays >= 1) {
            string suffix = timeDiff.TotalDays == 1 ? "day" : "days";
            return ((int) timeDiff.TotalDays) + " " + suffix + " ago";
        }
        
        if(timeDiff.TotalHours > 1) {
            int hourCount = (int) timeDiff.TotalHours;
            string suffix = hourCount == 1 ? "hour" : "hours";
            return hourCount + " " + suffix + " ago";
        }

        if(timeDiff.TotalMinutes > 1) {
            return ((int) timeDiff.TotalMinutes) + " minutes ago";
        }

        if(timeDiff.TotalMinutes == 1) {
            return "A minutes ago";
        }

        return ((int) timeDiff.TotalMinutes) + " seconds ago";
    }

}