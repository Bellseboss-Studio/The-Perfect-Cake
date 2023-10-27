using System;
using SystemOfExtras;
using UnityEngine;

public class CompletedMissionCustom : MonoBehaviour
{
    [SerializeField] private IdMissions idMission;

    public void CompletedMission()
    {
        ServiceLocator.Instance.GetService<IStatesMissions>().MissionCompleted(idMission);
    }
}