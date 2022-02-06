using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DailyTasks : MonoBehaviour
{

	public DailyTask StartEasyTask;
	public DailyTask StartMediumTask;
	public List<DailyTask> EasyTasks = new List<DailyTask>();
	public List<DailyTask> MediumTasks = new List<DailyTask>();
	public static DailyTasks Instance;


	private void Awake()
	{
		Instance = this;
		DataManager.GetIsRewardedForStartEasyTask(out StartEasyTask.IsRewarded);
		DataManager.GetIsRewardedForStartMediumTask(out StartMediumTask.IsRewarded);

	}

	private void Start()
	{

		if (StartEasyTask.IsRewarded == true && StartMediumTask.IsRewarded == true)
		{
			DataManager.GetEasyTaskProgress(out EasyTasks[0].ProgressOfDailyTask);
			DataManager.GetMediumTaskProgress(out MediumTasks[0].ProgressOfDailyTask);
			DataManager.GetIsRewardedForEasyTask(out EasyTasks[0].IsRewarded);
			DataManager.GetIsRewardedForMediumTask(out MediumTasks[0].IsRewarded);

			UIManager.ShowEasyTask(Instance.EasyTasks[0]);
			UIManager.ShowMediumTask(Instance.MediumTasks[0]);
		}
		else
		{
			DataManager.GetEasyTaskProgress(out StartEasyTask.ProgressOfDailyTask);
			DataManager.GetMediumTaskProgress(out StartMediumTask.ProgressOfDailyTask);

			UIManager.ShowEasyTask(Instance.StartEasyTask);
			UIManager.ShowMediumTask(Instance.StartMediumTask);
		}
	}

	public static void UpdateDailyTaskStatus(DailyTask Task)
	{
		if (!Task.IsRewarded)
		{
			Task.ProgressOfDailyTask++;
			if (Task.ProgressOfDailyTask >= Task.GoalProgressOfDailyTask)
			{
				Task.IsRewarded = true;
				DataManager.IncreaseAmountOfCurrency(Task.Reward);
			}
		}
	}

	public static void ChangeDailyTasks()
	{
		//In work
		Debug.Log("Tasks is changed...");
	}
}
