using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{
	public class TimeEventListView : MonoBehaviour {
		public RectTransform contentView;
		public EventItemView itemViewPrefab;
		public float spacing = 0;


		public void SetTimeEventList(List<TimeEventData> eventList)
		{
			ClearContent();

			float posY = -spacing;
			foreach(TimeEventData data in eventList) {
				posY = AddEventItemView(posY, data);
			}

			float totalHeight = -posY + 100;
			SetContentHeight(totalHeight);
		}

		float AddEventItemView(float posY, TimeEventData data)
		{
			GameObject newView = GameObject.Instantiate(itemViewPrefab.gameObject);

			EventItemView itemView = newView.GetComponent<EventItemView>();

			bool isUnlocked = MainGameManager.Instance.saveData.IsEventUnlocked(data.year);

			float height = isUnlocked ? itemView.unlockHeight : itemView.lockedHeight;
			height += spacing;

			
			itemView.SetEvent(data.eventName);
			itemView.SetYear(data.year);
			itemView.SetStatus(isUnlocked);

			RectTransform rt = newView.transform as RectTransform;
			rt.SetParent(contentView, false);
			rt.anchoredPosition = new Vector2(0, posY);
			
			return posY - height;
		}



		public void SetContentHeight(float height) {
			Vector2 size = contentView.sizeDelta;

			size.y = height;

			contentView.sizeDelta = size;
		}

		public void ClearContent() {
			for(int i=0; i<contentView.childCount; i++) {
				Transform t = contentView.GetChild(i);
				GameObject.Destroy(t.gameObject);
			}
		}
	}
}