using System.Collections.Generic;
using SystemOfExtras;

public class StatesOfStatesMissions : IStatesMissions
{
    private Dictionary<IdMissions, bool> listOfMissions;

    public StatesOfStatesMissions()
    {
        listOfMissions = new Dictionary<IdMissions, bool>();
    }

    public bool IsActiveMission(IdMissions idMissions)
    {
        if (listOfMissions.TryGetValue(idMissions, out var value))
        {
            return value;
        }

        return false;
    }

    public void AddMission(IdMissions idMissions)
    {
        if (listOfMissions.TryGetValue(idMissions, out var value))
        {
            listOfMissions[idMissions] = true;
            return;
        }
        listOfMissions.Add(idMissions, true);
    }
}