using System.Collections;
using SystemOfExtras;
using UnityEngine;

public class AddMissionCustom : MonoBehaviour
{
    [SerializeField] private IdMissions idMission;
    [SerializeField] private string nameMission, descriptionMission;
    [SerializeField] private bool isStart;
    private void Start()
    {
        if (isStart)
        {
            StartCoroutine(AddMissionCustomMethod());
        }
    }
    
    public void AddMission()
    {
        ServiceLocator.Instance.GetService<IStatesMissions>().AddMission(idMission, nameMission, descriptionMission);
    }

    public IEnumerator AddMissionCustomMethod()
    {
        yield return new WaitForSeconds(5f);
        AddMission();
    }
}