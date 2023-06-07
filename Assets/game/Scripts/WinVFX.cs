using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinVFX : Singleton<WinVFX>
{
    public Transform[] rects;
    public Transform[] initialTF;
    public float scaleTime;

    private void Start()
    {
        OnDestroy();
    }

    public void OnInit(Vector3 pos)
    {
        Cache.GetTransform(this.gameObject).position = pos;
        for(int i = 0; i < rects.Length; i++)
        {
            int index = i;
            rects[index].gameObject.SetActive(true);
            rects[index].position = initialTF[index].position;
            rects[index]
                .DOLocalMove(rects[index].localPosition + rects[index].up*1.2f, 0.5f)
                .SetEase(Ease.OutCubic)
                .OnComplete(() =>
                {
                    rects[index].gameObject.SetActive(false);
                })
                ;
            //scale
            rects[index].localScale = initialTF[index].localScale;
            rects[index]
                .DOScaleY(initialTF[index].localScale.y*3f, scaleTime)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    rects[index]
                        .DOScaleY(initialTF[index].localScale.y * 1f, scaleTime)
                        .SetEase(Ease.Linear);
                })
                ;
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
