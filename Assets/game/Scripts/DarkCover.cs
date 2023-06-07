using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkCover : MonoBehaviour
{
    [SerializeField] private Image image;
    public Color transparent;
    public Color dark;
    public float duration;

    private void OnEnable()
    {
        ResetColor();
        TurnDarker();
    }

    public void TurnDarker()
    {
        image
            .DOColor(dark, duration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                this.gameObject.SetActive(false);
            })
            ;
    }

    public void ResetColor()
    {
        image.color = transparent;
    }
}
