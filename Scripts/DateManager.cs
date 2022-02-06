using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateManager : MonoBehaviour
{
	private DateTime PlayerDate = DateTime.Now;
	private DateTime LifeTimeOfDailyTask = DateTime.Today.AddDays(1);
	private TimeSpan RemainedTimeToUpdate;

	private void Start()
	{

		if (DataManager.GetFirstEnter())
		{
			DataManager.SetFirstEnter();
			DataManager.SaveUserDate(DateTime.Today.ToShortDateString());
		}

		if (DateTime.Today.ToShortDateString() != DataManager.GetUserDate())
		{
			DataManager.SaveUserDate(DateTime.Today.ToShortDateString());

			DailyTasks.ChangeDailyTasks();
		}
	}

	private void Update()
	{
		PlayerDate = DateTime.Now;
		RemainedTimeToUpdate = LifeTimeOfDailyTask.Subtract(PlayerDate);

		UIManager.Instance.RemainingTimeUpdate.text = RemainedTimeToUpdate.ToString(@"hh\:mm\:ss");
	}
}
