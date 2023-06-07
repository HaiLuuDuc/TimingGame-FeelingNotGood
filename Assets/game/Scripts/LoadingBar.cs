using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBar : MonoBehaviour
{
    [SerializeField] private RectTransform whiteBar;
    [SerializeField] private RectTransform yellowBar;
    [SerializeField] private float step;
    private float initialWidth;
    private float initialHeight;


    private void Start()
    {
        SetUp();
        StartCoroutine(LoadingCoroutine());
    }

    public void SetUp()
    {
        initialWidth = yellowBar.sizeDelta.x;
        initialHeight = yellowBar.sizeDelta.y;
        yellowBar.sizeDelta = new Vector2(0, initialHeight);
    }

    public IEnumerator LoadingCoroutine()
    {
        while (yellowBar.sizeDelta.x < initialWidth)
        {
            //scale
            Vector2 targetSizeDelta = new Vector2(yellowBar.sizeDelta.x + step*Time.deltaTime, initialHeight);
            yellowBar.sizeDelta = targetSizeDelta;

            //position
            float xOffset = (yellowBar.sizeDelta.x / initialWidth) / 2 * initialWidth ;
            float newX = (whiteBar.localPosition.x - initialWidth / 2) + xOffset;
            yellowBar.localPosition = new Vector2(newX, yellowBar.localPosition.y);

            yield return null;
        }

        UIManager.Ins.CloseUI<Loading>();
        UIManager.Ins.OpenUI<MainMenu>();
        
        yield return null;
    }

    
}
