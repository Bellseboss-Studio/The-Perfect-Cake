using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionDetailUiView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title, description;
    [SerializeField] private Image image;

    public void Config(MissionDetail missionDetail)
    {
        title.text = missionDetail.nameOfMission;
        description.text = missionDetail.descriptionOfMission;
        missionDetail.onCompleted += MissionDetailOnOnCompleted;
    }

    private void MissionDetailOnOnCompleted()
    {
        Debug.Log("Mission Completed");
        image.color = Color.green;
    }
}
