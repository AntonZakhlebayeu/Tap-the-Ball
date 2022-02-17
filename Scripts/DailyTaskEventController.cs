using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DailyTaskEventController
{
	public static void Subscribe(DailyTask EasyTask, DailyTask MediumTask)
	{
		if (DailyTasks.IsStarterTasksCompleted())
		{
			switch (EasyTask.TypeOfDailyTask)
			{
				case DailyTaskType.Diamond:
					Currency.DiamondCollected += EasyTaskHandler;
					break;
				case DailyTaskType.Obstacle:
					ScorePoint.ObstacleAvoided += EasyTaskHandler;
					break;
				case DailyTaskType.ColorChanging:
					ScorePoint.ColorChanged += EasyTaskHandler;
					break;
			}

			switch (MediumTask.TypeOfDailyTask)
			{
				case DailyTaskType.Diamond:
					Currency.DiamondCollected += MediumTaskHandler;
					break;
				case DailyTaskType.Obstacle:
					ScorePoint.ObstacleAvoided += MediumTaskHandler;
					break;
				case DailyTaskType.ColorChanging:
					ScorePoint.ColorChanged += MediumTaskHandler;
					break;
			}
		}
		else
		{
			Currency.DiamondCollected += EasyTaskHandler;
			ScorePoint.ObstacleAvoided += MediumTaskHandler;
		}
	}

	public static void Unsubscribe(DailyTask EasyTask, DailyTask MediumTask)
	{
		if (DailyTasks.IsStarterTasksCompleted())
		{
			Currency.DiamondCollected -= EasyTaskHandler;
			ScorePoint.ObstacleAvoided -= EasyTaskHandler;
			ScorePoint.ColorChanged -= EasyTaskHandler;

			Currency.DiamondCollected -= MediumTaskHandler;
			ScorePoint.ObstacleAvoided -= MediumTaskHandler;
			ScorePoint.ColorChanged -= MediumTaskHandler;
		}
		else
		{
			Currency.DiamondCollected -= EasyTaskHandler;
			ScorePoint.ObstacleAvoided -= MediumTaskHandler;
		}
	}

	public static void EasyTaskHandler()
	{
		if (!DailyTasks.IsStarterTasksCompleted()) DailyTasks.UpdateDailyTaskStatus(DailyTasks.Instance.StarterEasyTask);
		else DailyTasks.UpdateDailyTaskStatus(DailyTasks.Instance.EasyTasks[DailyTasks.DailyTasksIndex]);
	}

	public static void MediumTaskHandler()
	{
		if (!DailyTasks.IsStarterTasksCompleted()) DailyTasks.UpdateDailyTaskStatus(DailyTasks.Instance.StarterMediumTask);
		else DailyTasks.UpdateDailyTaskStatus(DailyTasks.Instance.MediumTasks[DailyTasks.DailyTasksIndex]);
	}


}
