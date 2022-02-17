using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DailyTaskType
{
	Diamond,
	Obstacle,
	ColorChanging
}


public class DailyTask : MonoBehaviour
{
	public string DailyTaskText;
	public int ProgressOfDailyTask;
	public int GoalProgressOfDailyTask;
	public int Reward;
	public bool IsRewarded;
	public DailyTaskType TypeOfDailyTask;
}
