using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DailyTasks : MonoBehaviour
{
	public DailyTask StarterEasyTask;
	public DailyTask StartMediumTask;

	public List<DailyTask> EasyTasks = new List<DailyTask>();
	public List<DailyTask> MediumTasks = new List<DailyTask>();


	public static DailyTasks Instance;
	public static int DailyTasksIndex;

	private void Awake()
	{
		Instance = this;

		GetStarterTasksProgress();
	}

	private void Start()
	{
		if (IsStarterTasksCompleted())
		{
			DailyTasksIndex = DataManager.GetDailyTasksIndices();

			GetProgress();
			UpdateUI();
		}
		else
		{
			UpdateUIStartTasks();
		}
	}

	public bool IsStarterTasksCompleted()
	{
		if (StarterEasyTask.IsRewarded == true && StartMediumTask.IsRewarded == true)
			return true;
		else
			return false;
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
		DailyTasksIndex = DataManager.GetDailyTasksIndices();
		DailyTasksIndex++;
		if (DailyTasksIndex == 4)
		{
			DailyTasksIndex = 0;
			DataManager.SaveDailyTasksIndices(DailyTasksIndex);
		}
		else
			DataManager.SaveDailyTasksIndices(DailyTasksIndex);

		ResetProgress();
	}

	public static void ResetProgress()
	{
		DataManager.SaveEasyTaskProgress(0);
		DataManager.SaveMediumTaskProgress(0);
		DataManager.SaveIsRewaredForEasyTask(false);
		DataManager.SaveIsRewaredForMediumTask(false);
	}

	public static void UpdateUI()
	{
		UIManager.ShowEasyTask(Instance.EasyTasks[DailyTasksIndex]);
		UIManager.ShowMediumTask(Instance.MediumTasks[DailyTasksIndex]);
	}

	public static void UpdateUIStartTasks()
	{
		UIManager.ShowEasyTask(Instance.StarterEasyTask);
		UIManager.ShowMediumTask(Instance.StartMediumTask);
	}

	public static void GetProgress()
	{
		DataManager.GetEasyTaskProgress(out Instance.EasyTasks[DailyTasksIndex].ProgressOfDailyTask);
		DataManager.GetMediumTaskProgress(out Instance.MediumTasks[DailyTasksIndex].ProgressOfDailyTask);
		DataManager.GetIsRewardedForEasyTask(out Instance.EasyTasks[DailyTasksIndex].IsRewarded);
		DataManager.GetIsRewardedForMediumTask(out Instance.MediumTasks[DailyTasksIndex].IsRewarded);
	}

	public static void GetStarterTasksProgress()
	{
		DataManager.GetEasyTaskProgress(out Instance.StarterEasyTask.ProgressOfDailyTask);
		DataManager.GetMediumTaskProgress(out Instance.StartMediumTask.ProgressOfDailyTask);

		DataManager.GetIsRewardedForStarterEasyTask(out Instance.StarterEasyTask.IsRewarded);
		DataManager.GetIsRewardedForStarterMediumTask(out Instance.StartMediumTask.IsRewarded);
	}


	public static void SaveDailyTasksProgress()
	{
		DataManager.SaveEasyTaskProgress(Instance.EasyTasks[DailyTasks.DailyTasksIndex].ProgressOfDailyTask);
		DataManager.SaveMediumTaskProgress(Instance.MediumTasks[DailyTasks.DailyTasksIndex].ProgressOfDailyTask);
		DataManager.SaveIsRewaredForEasyTask(Instance.EasyTasks[DailyTasks.DailyTasksIndex].IsRewarded);
		DataManager.SaveIsRewaredForMediumTask(Instance.MediumTasks[DailyTasks.DailyTasksIndex].IsRewarded);

		DataManager.SaveIsRewaredForStarterEasyTask(Instance.StarterEasyTask.IsRewarded);
		DataManager.SaveIsRewaredForStarterMediumTask(Instance.StartMediumTask.IsRewarded);
	}

	public static void SaveStarterTasksProgress()
	{
		DataManager.SaveEasyTaskProgress(Instance.StarterEasyTask.ProgressOfDailyTask);
		DataManager.SaveMediumTaskProgress(Instance.StartMediumTask.ProgressOfDailyTask);
		DataManager.SaveIsRewaredForStarterEasyTask(Instance.StarterEasyTask.IsRewarded);
		DataManager.SaveIsRewaredForStarterMediumTask(Instance.StartMediumTask.IsRewarded);
	}
}
