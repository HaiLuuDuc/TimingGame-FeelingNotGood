using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraController : Singleton<CameraController>
{
    [SerializeField] private PostProcessVolume postProcessVolume;


    private void Start()
    {
        OnReset();
    }

    public void OnReset()
    {
        DisableBlackWhite();
    }

    public void OnLose()
    {
        EnableBlackWhite();
    }

    public void EnableBlackWhite()
    {
        postProcessVolume.enabled = true;
    }

    public void DisableBlackWhite()
    {
        postProcessVolume.enabled = false;
    }
}
