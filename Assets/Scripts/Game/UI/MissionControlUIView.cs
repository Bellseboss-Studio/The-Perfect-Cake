using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;

public class MissionControlUIView : MonoBehaviour, IStatesMissionsView
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform content;
    [SerializeField] private MissionDetailUiView missionDetailUiViewPrefab;
    private List<MissionDetailUiView> missionDetailUiViewPrefabs;
    private bool isOpen;

    public void Config()
    {
        ServiceLocator.Instance.RegisterService<IStatesMissionsView>(this);
        ServiceLocator.Instance.GetService<IStatesMissions>().OnAddMission += AddMission;
    }

    private void AddMission(MissionDetail missionDetail)
    {
        var missionDetailUiView = Instantiate(missionDetailUiViewPrefab, content);
        missionDetailUiView.Config(missionDetail);
        missionDetail.onCompleted += () =>
        {
            missionDetailUiView.transform.SetAsLastSibling();
            Destroy(missionDetailUiView.gameObject, 5f);
        };
        missionDetailUiView.transform.SetAsFirstSibling();
    }

    public void OpenMissionsTab()
    {
        animator.SetBool("open", isOpen);
        isOpen = !isOpen;
    }
}