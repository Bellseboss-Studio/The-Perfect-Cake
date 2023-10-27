using System;
using System.Collections;
using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;

public class PuertaInteractuable : InteractiveObjectFather
{
    [SerializeField] private bool canUseDoor;
    private Vector3 rotationFinal;
    private Vector3 rotationInicial;
    [SerializeField] private bool closeDoor;
    [SerializeField] private bool canUseAgain = true;
    [SerializeField] private AddMissionCustom addMissionInQuest;

    private void Start()
    {
        rotationInicial = rotationFinal = transform.localRotation.eulerAngles;
        rotationFinal.y += 220;
    }

    private void Update()
    {
        if (closeDoor)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(rotationInicial), Time.deltaTime);
            //Debug.Log($"transform.localRotation {transform.localRotation.eulerAngles.y}");
            if ((transform.localRotation.eulerAngles.y - 0) < 1)
            {
                closeDoor = false;
            }
        }
        if (!canUseAgain) return;
        if (canUseDoor)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(rotationFinal), Time.deltaTime);
            if ((transform.localRotation.eulerAngles.y - 220) < 1)
            {
                canUseDoor = false;
            }
        }

    }

    protected override void ActionEventCustom()
    {
        Debug.Log("Se abre la puerta");
        canUseDoor = true;   
    }

    public void CloseDoor()
    {
        canUseDoor = false;
        closeDoor = true;
        canUseAgain = false;
        Destroy(GetComponent<InteractiveObject>());
        ServiceLocator.Instance.GetService<IStatesMissions>().MissionCompleted(IdMissions.GO_OUT_TO_HOME);
        addMissionInQuest.AddMission();
    }
}