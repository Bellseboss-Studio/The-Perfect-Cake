using System.Collections;
using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;

public class MisionJugete : InteractiveObject
{
    [SerializeField] private Item jugete;
    [SerializeField] private Dialog dialogoConUnJugete, dialogoSinJugetesPeroConLaMision;
    private int countItemSaved;
    public int CountItemSaved => countItemSaved;
    public Item Toy => jugete;
    public override void OnMouseDown()
    {
        if (ServiceLocator.Instance.GetService<IStatesMissions>().IsActiveMission(IdMissions.JUGETE))
        {
            if (ServiceLocator.Instance.GetService<IItemsInventory>().SearchItemForId(jugete.Id))
            {
                SetDialogo(dialogoConUnJugete);
            }
            else
            {
                SetDialogo(dialogoSinJugetesPeroConLaMision);
            }
            
        }
        base.OnMouseDown();
    }

    public void AddToys(int removeItemById)
    {
        countItemSaved += removeItemById;
    }

    public bool HasCompletedMission()
    {
        return countItemSaved >= 3;
    }

    public void ConcatDialog(Dialog dialogoAgradecimiento)
    {
        ServiceLocator.Instance.GetService<IDialogSystem>().GetCurrentDialog().Concat(dialogoAgradecimiento);
    }
}

public enum IdMissions
{
    JUGETE,
    HARINA,
    AZUCAR,
    HUEVO,
    VENENO,
    GO_OUT_TO_HOME,
    GO_OUT_OF_BUILD,
    GO_TO_THE_MALL,
    GO_TO_HOME,
    GO_TO_APARTMENT,
}