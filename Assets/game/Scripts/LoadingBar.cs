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
        StartCoroutine(Loading());
    }

    public IEnumerator Loading()
    {
        while (yellowBar.sizeDelta.x < initialWidth)
        {
            Vector2 targetSizeDelta = new Vector2(yellowBar.sizeDelta.x + step, initialHeight);
            yellowBar.sizeDelta = targetSizeDelta;
            yield return null;
        }
        UIManager.Ins.CloseUI<Loading>();
        UIManager.Ins.OpenUI<MainMenu>();
        
        yield return null;
    }

    public void SetUp()
    {
        initialWidth = yellowBar.sizeDelta.x;
        initialHeight = yellowBar.sizeDelta.y;
        yellowBar.sizeDelta = new Vector2(0, initialHeight);
    }
}
