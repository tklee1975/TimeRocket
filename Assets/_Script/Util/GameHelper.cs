using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder 
{
	public class GameTime {
		public const int kDayPerYear = 365;

		public int year;
		public int day;
		public float totalDays;

		public GameTime() {

		}

		public GameTime(int _year, int _day) {
			year = _year;
			day = _day;
			UpdateTimeFromYearDay();
		}

		public GameTime(float  _total) {
			totalDays = _total;

			UpdateYearDayFromTime();
		}

		public void SetYearDay(int _year, int _day) {
			year = _year;
			day = _day;

			UpdateTimeFromYearDay();
		}

		public void ReduceTime(float dayDelta) {
			totalDays -= dayDelta;
			if(totalDays <= 0) {
				totalDays = 0;
			}

			UpdateYearDayFromTime();
		}



		public void UpdateTimeFromYearDay() {
			totalDays = year * kDayPerYear + day;
		}

		public void UpdateYearDayFromTime() {
			year = Mathf.FloorToInt(totalDays / kDayPerYear);
			day = (int)(totalDays - year * kDayPerYear);
			if(day < 0) {
				day = 0;
			}
		}

		public string Info() {
			return "YEAR: " + year + " day: " + day + " totalDays: " + totalDays;
		}
	}


	public class GameHelper  {
		//public const int kDayPerYear = 365;

		

	}

}