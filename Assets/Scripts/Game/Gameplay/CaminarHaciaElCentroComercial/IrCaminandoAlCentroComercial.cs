using System;
using System.Collections;
using System.Collections.Generic;
using GameAudio;
using SystemOfExtras;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrCaminandoAlCentroComercial : MonoBehaviour
{
    [SerializeField] private int minutos;
    [SerializeField] private int nextScene;
    private void OnTriggerEnter(Collider other)
    {
        ServiceLocator.Instance.GetService<ITimeService>().AddMinutes(minutos);
        ServiceLocator.Instance.GetService<InteractablesSounds>().PlaySound("000_Caminando");
        ServiceLocator.Instance.GetService<ILoadScream>().Close(() =>
        {
            SceneManager.LoadScene(nextScene);
        });
    }

    private void OnCollisionEnter(Collision other)
    {
        ServiceLocator.Instance.GetService<ITimeService>().AddMinutes(minutos);
        ServiceLocator.Instance.GetService<InteractablesSounds>().PlaySound("000_Caminando");
        ServiceLocator.Instance.GetService<ILoadScream>().Close(() =>
        {
            SceneManager.LoadScene(nextScene);
        });
    }
}