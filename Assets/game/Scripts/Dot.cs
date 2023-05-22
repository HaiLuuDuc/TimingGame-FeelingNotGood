using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite winDot;
    [SerializeField] private Sprite loseDot;
    [SerializeField] private Sprite initialDot;
    private bool isBig = false;

    private void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        Cache.GetTransform(this.gameObject).localScale = Vector3.one;
        image.sprite = initialDot;
        isBig = false;
    }

    public void OnWin()
    {
        image.sprite = winDot;
        TurnBigger();
    }

    public void OnLose()
    {
        image.sprite = loseDot;
        TurnBigger();
    }

    public void TurnBigger()
    {
        if(isBig == false)
        {
            Vector3 oldScale = Cache.GetTransform(this.gameObject).localScale;
            Vector3 newScale = oldScale * 1.4f;
            Cache.GetTransform(this.gameObject).localScale = newScale;
            isBig = true;
        }
    }
}
