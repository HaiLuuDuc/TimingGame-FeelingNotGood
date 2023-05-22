using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStart : BaseButton
{
    protected override void OnClick()
    {
        UIManager.Ins.CloseUI<MainMenu>();
        UIManager.Ins.OpenUI<Gameplay>();
        LevelManager.Ins.LoadLevel(0);
        LeaderboardManager.Ins.ResetCurrentPassedLevel();
        LeaderboardManager.Ins.ResetCurrentTotalTime();
    }
}
