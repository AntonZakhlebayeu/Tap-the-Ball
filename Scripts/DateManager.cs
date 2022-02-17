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
		if (DateTime.Today.ToShortDateString() != DataManager.GetUserDate())
		{
			DataManager.SaveUserDate(DateTime.Today.ToShortDateString());

			DailyTasks.ChangeDailyTasks();
			if (DailyTasks.IsStarterTasksCompleted())
				DailyTasks.UpdateUI();
		}
	}

	private void FixedUpdate()
	{
		PlayerDate = DateTime.Now;
		RemainedTimeToUpdate = LifeTimeOfDailyTask.Subtract(PlayerDate);

		if (RemainedTimeToUpdate.Hours as int? == 0 && RemainedTimeToUpdate.Minutes as int? == 0
		&& RemainedTimeToUpdate.Seconds as int? == 0 && RemainedTimeToUpdate.Milliseconds as int? < 2)
		{
			DailyTasks.ChangeDailyTasks();

			if (DailyTasks.IsStarterTasksCompleted())
				DailyTasks.UpdateUI();

			LifeTimeOfDailyTask = DateTime.Today.AddDays(1);
			DataManager.SaveUserDate(DateTime.Now.ToShortDateString());
		}

		if (!Variables._IsDarkMode)
			UIManager.Instance.RemainingTimeUpdate.text = RemainedTimeToUpdate.ToString(@"hh\:mm\:ss");
		else
			UIManager.Instance.RemainingTimeUpdateWhite.text = RemainedTimeToUpdate.ToString(@"hh\:mm\:ss");
	}
}
