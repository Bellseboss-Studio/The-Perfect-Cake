using UnityEngine;

public class TriggerToCompletedMission : MonoBehaviour
{
    [SerializeField] private CompletedMissionCustom completedMissionCustom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            completedMissionCustom.CompletedMission();
        }
    }
}