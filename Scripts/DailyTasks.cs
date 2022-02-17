using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyTasks : MonoBehaviour
{
	public DailyTask StarterEasyTask;
	public DailyTask StarterMediumTask;

	public List<DailyTask> EasyTasks = new List<DailyTask>();
	public List<DailyTask> MediumTasks = new List<DailyTask>();


	public static DailyTasks Instance;
	public static int DailyTasksIndex;

	private void Awake()
	{
		Instance = this;

		DailyTaskDataController.GetStarterTasksProgress();
	}

	private void Start()
	{
		if (IsStarterTasksCompleted())
		{
			DailyTasksIndex = DataManager.GetDailyTasksIndices();

			DailyTaskEventController.Subscribe(EasyTasks[DailyTasksIndex], MediumTasks[DailyTasksIndex]);

			DailyTaskDataController.GetProgress();
			UpdateUI();
		}
		else
		{
			DailyTaskEventController.Subscribe(StarterEasyTask, StarterMediumTask);
			UpdateUIStartTasks();
		}
	}

	public static bool IsStarterTasksCompleted()
	{
		if (Instance.StarterEasyTask.IsRewarded == true && Instance.StarterMediumTask.IsRewarded == true)
		{
			return true;
		}

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
		DailyTaskEventController.Unsubscribe(Instance.EasyTasks[DailyTasksIndex], Instance.MediumTasks[DailyTasksIndex]);
		DailyTasksIndex++;
		if (DailyTasksIndex == 4)
		{
			DailyTasksIndex = 0;
			DataManager.SaveDailyTasksIndices(DailyTasksIndex);
		}
		else
			DataManager.SaveDailyTasksIndices(DailyTasksIndex);
		DailyTaskEventController.Subscribe(Instance.EasyTasks[DailyTasksIndex], Instance.MediumTasks[DailyTasksIndex]);
		ResetProgress();
	}

	public static void UpdateUI()
	{
		UIManager.ShowEasyTask(Instance.EasyTasks[DailyTasksIndex]);
		UIManager.ShowMediumTask(Instance.MediumTasks[DailyTasksIndex]);
	}

	public static void UpdateUIStartTasks()
	{
		UIManager.ShowEasyTask(Instance.StarterEasyTask);
		UIManager.ShowMediumTask(Instance.StarterMediumTask);
	}

	public static void ResetProgress()
	{
		DataManager.SaveEasyTaskProgress(0);
		DataManager.SaveMediumTaskProgress(0);
		DataManager.SaveIsRewaredForEasyTask(false);
		DataManager.SaveIsRewaredForMediumTask(false);
	}
}
