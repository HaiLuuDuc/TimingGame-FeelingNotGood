using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite winDot;
    [SerializeField] private Sprite progressDot;
    [SerializeField] private Sprite initialDot;

    public void OnInit()
    {
        Cache.GetTransform(this.gameObject).localScale = Vector3.one;
        image.sprite = initialDot;
    }

    public void OnProgress()
    {
        image.sprite = progressDot;
        TurnBigger();
    }

    public void OnWin()
    {
        image.sprite = winDot;
    }

    public void TurnBigger()
    {
        transform.DOScale(1.5f, 0.3f);
    }

    public void TurnSmaller()
    {
        transform.DOScale(1f, 0.3f);
    }
}
