using System;
using System.Collections.Generic;
using SystemOfExtras;

public class StatesOfStatesMissions : IStatesMissions
{
    private Dictionary<IdMissions, MissionDetail> listOfMissions;

    public StatesOfStatesMissions()
    {
        listOfMissions = new Dictionary<IdMissions, MissionDetail>();
    }

    public StatesOfStatesMissions(List<MissionDetail> ingredientsDetails)
    {
        listOfMissions = new Dictionary<IdMissions, MissionDetail>();
        foreach (var missionDetail in ingredientsDetails)
        {
            listOfMissions.Add(missionDetail.idMissions, missionDetail);
        }
    }

    public bool IsActiveMission(IdMissions idMissions)
    {
        return listOfMissions.TryGetValue(idMissions, out var value) && value.IsCompleted;
    }

    public void AddMission(IdMissions idMissions)
    {
        AddMission(idMissions, idMissions.ToString(), "");
    }
    public void AddMission(IdMissions idMissions, string name, string description)
    {
        if (listOfMissions.TryGetValue(idMissions, out var value))
        {
            listOfMissions[idMissions].IsCompleted = true;
            return;
        }

        var missionDetail = new MissionDetail()
        {
            idMissions = idMissions,
            IsCompleted = false,
            nameOfMission = name,
            descriptionOfMission = description
        };
        listOfMissions.Add(idMissions, missionDetail);
        OnAddMission?.Invoke(missionDetail);
    }

    public void MissionCompleted(IdMissions idMissions)
    {
        if (listOfMissions.TryGetValue(idMissions, out var value))
        {
            value.IsCompleted = true;
        }
    }

    public List<MissionDetail> GetMissionsActive()
    {
        return new List<MissionDetail>(listOfMissions.Values);
    }

    public Action<MissionDetail> OnAddMission { get; set; }
}