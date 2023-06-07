using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseVFX : Singleton<LoseVFX>
{
    public Transform[] rects;

    private void Start()
    {
        OnDestroy();
    }

    public void OnInit(Vector3 pos)
    {
        Cache.GetTransform(this.gameObject).position = pos;
        for (int i = 0; i < rects.Length; i++)
        {
            rects[i].gameObject.SetActive(true);
        }
    }

    public void OnDestroy()
    {
        for (int i = 0; i < rects.Length; i++)
        {
            rects[i].gameObject.SetActive(false);
        }
    }
}
