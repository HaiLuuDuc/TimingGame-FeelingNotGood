using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContinueInLose : BaseButton
{
    protected override void OnClick()
    {
        StartCoroutine(ContinueCoroutine());
    }

    public IEnumerator ContinueCoroutine()
    {
        UIManager.Ins.OpenUI<Ads>();
        Cache.GetRectTransform(UIManager.Ins.OpenUI<Ads>().gameObject).SetAsLastSibling();
        yield return StartCoroutine(Ads.instance.CloseAfter(2f));
        Gameplay.instance.dots[LevelManager.Ins.currentLevelIndex].OnWin();
        LevelManager.Ins.DestroyCurrentLevel();
        LevelManager.Ins.LoadNextLevel();
        UIManager.Ins.CloseUI<Lose>();
        LeaderboardManager.Ins.OnSkip();
        CameraController.Ins.OnReset();
        WinVFX.Ins.OnDestroy();
        yield return null;
    }
}
