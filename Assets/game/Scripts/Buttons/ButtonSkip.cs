using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSkip : BaseButton
{
    protected override void OnClick()
    {
        if (LevelManager.Ins.currentLevel.isLaunched == true)
        {
            return;
        }
        else
        {
            StartCoroutine(Skip());
        }
    }

    public IEnumerator Skip()
    {
        UIManager.Ins.OpenUI<Ads>();
        yield return StartCoroutine(Ads.instance.CloseAfter(5f));
        Gameplay.instance.dots[LevelManager.Ins.currentLevelIndex].OnWin();
        LevelManager.Ins.DestroyCurrentLevel();
        LevelManager.Ins.LoadNextLevel();
        LeaderboardManager.Ins.OnSkip();
        yield return null;
    }
}
