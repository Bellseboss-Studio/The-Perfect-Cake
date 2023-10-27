using System;
using System.Collections;
using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;

public class InitializationInScene2 : MonoBehaviour
{
    [SerializeField] private float delayInSeconds = 0;
    [SerializeField] private GameObject pointToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        var transformPlayer = ServiceLocator.Instance.GetService<IItemsInventory>().GetTransformPlayer();
        transformPlayer.position = pointToSpawn.transform.position;
        transformPlayer.rotation = pointToSpawn.transform.rotation;
        Debug.Log(">>>>>>>>>>>>>>>>>teleport to player");
        StartCoroutine(DelayFadeIn(delayInSeconds));
    }

    private IEnumerator DelayFadeIn(float delay)
    {
       yield return new WaitForSeconds(delay);
       ServiceLocator.Instance.GetService<ILoadScream>().Open(() => { });
        
    }
    
    
}