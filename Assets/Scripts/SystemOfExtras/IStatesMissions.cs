using System;
using System.Collections.Generic;

namespace SystemOfExtras
{
    public interface IStatesMissions
    {
        bool IsActiveMission(IdMissions idMissions);
        void AddMission(IdMissions idMissions);
        void AddMission(IdMissions idMissions, string name, string description);
        void MissionCompleted(IdMissions idMissions);
        List<MissionDetail> GetMissionsActive();
        Action<MissionDetail> OnAddMission { get; set; }
    }
}