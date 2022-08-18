using System;
using System.Collections;
using Game.VisorDeDialogosSystem;
using SystemOfExtras;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    private bool hasEnableShader;
    private Renderer _renderer = null;
    [SerializeField] private Dialog idDialog;
    public Action OnInteractionFinished;
    private Dialog _originalDialog;

    private void Start()
    {
        if (TryGetComponent<Renderer>(out var render))
        {
            _renderer = render;
        }
        _originalDialog = idDialog;
    }

    public void OnMouseDown()
    {
        /*Debug.Log("Click en el objeto");*/
        ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(idDialog.Id);
        ServiceLocator.Instance.GetService<IDialogSystem>().OnDialogAction( isDialog =>
        {
            foreach (var component in gameObject.GetComponents<IInteractiveObject>())
            {
                component.OnAction(isDialog);
            }
        });
        ServiceLocator.Instance.GetService<IDialogSystem>().OnDialogFinish(() =>
        {
            InteractionFinished();
        });
    }

    private void InteractionFinished()
    {
        Debug.Log($"Finish interaction");
        OnInteractionFinished?.Invoke();
    }

    public void SelectedOption(int keyPress)
    {
        ServiceLocator.Instance.GetService<IDialogSystem>().SelectOption(keyPress);
    }

    //Logic of Shaders
    public void EnableShader()
    {
        hasEnableShader = true;
        _renderer?.material.SetFloat("_Fresnel",1);
        StartCoroutine(DisableShader());

    }

    private void LateUpdate()
    {
        hasEnableShader = false;
    }

    private IEnumerator DisableShader()
    {
        yield return new WaitForSeconds(.5f);
        if (!hasEnableShader)
        {
            _renderer?.material.SetFloat("_Fresnel",0);
        }
    }

    public void SetDialogo(Dialog cambioDeDialogoDeLlave)
    {
        idDialog = cambioDeDialogoDeLlave;
    }

    public void RestoreDialog()
    {
        idDialog = _originalDialog;
    }
}