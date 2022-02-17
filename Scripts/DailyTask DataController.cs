using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DailyTaskDataController
{
	public static void GetProgress()
	{
		DataManager.GetEasyTaskProgress(out DailyTasks.Instance.EasyTasks[DailyTasks.DailyTasksIndex].ProgressOfDailyTask);
		DataManager.GetMediumTaskProgress(out DailyTasks.Instance.MediumTasks[DailyTasks.DailyTasksIndex].ProgressOfDailyTask);
		DataManager.GetIsRewardedForEasyTask(out DailyTasks.Instance.EasyTasks[DailyTasks.DailyTasksIndex].IsRewarded);
		DataManager.GetIsRewardedForMediumTask(out DailyTasks.Instance.MediumTasks[DailyTasks.DailyTasksIndex].IsRewarded);
	}

	public static void GetStarterTasksProgress()
	{
		DataManager.GetEasyTaskProgress(out DailyTasks.Instance.StarterEasyTask.ProgressOfDailyTask);
		DataManager.GetMediumTaskProgress(out DailyTasks.Instance.StarterMediumTask.ProgressOfDailyTask);

		DataManager.GetIsRewardedForStarterEasyTask(out DailyTasks.Instance.StarterEasyTask.IsRewarded);
		DataManager.GetIsRewardedForStarterMediumTask(out DailyTasks.Instance.StarterMediumTask.IsRewarded);
	}


	public static void SaveDailyTasksProgress()
	{
		DataManager.SaveEasyTaskProgress(DailyTasks.Instance.EasyTasks[DailyTasks.DailyTasksIndex].ProgressOfDailyTask);
		DataManager.SaveMediumTaskProgress(DailyTasks.Instance.MediumTasks[DailyTasks.DailyTasksIndex].ProgressOfDailyTask);
		DataManager.SaveIsRewaredForEasyTask(DailyTasks.Instance.EasyTasks[DailyTasks.DailyTasksIndex].IsRewarded);
		DataManager.SaveIsRewaredForMediumTask(DailyTasks.Instance.MediumTasks[DailyTasks.DailyTasksIndex].IsRewarded);

		DataManager.SaveIsRewaredForStarterEasyTask(DailyTasks.Instance.StarterEasyTask.IsRewarded);
		DataManager.SaveIsRewaredForStarterMediumTask(DailyTasks.Instance.StarterMediumTask.IsRewarded);
	}

	public static void SaveStarterTasksProgress()
	{
		DataManager.SaveEasyTaskProgress(DailyTasks.Instance.StarterEasyTask.ProgressOfDailyTask);
		DataManager.SaveMediumTaskProgress(DailyTasks.Instance.StarterMediumTask.ProgressOfDailyTask);
		DataManager.SaveIsRewaredForStarterEasyTask(DailyTasks.Instance.StarterEasyTask.IsRewarded);
		DataManager.SaveIsRewaredForStarterMediumTask(DailyTasks.Instance.StarterMediumTask.IsRewarded);
	}

}
