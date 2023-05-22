using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLeaderboard : BaseButton
{
    protected override void OnClick()
    {
        UIManager.Ins.OpenUI<Leaderboard>();
    }
}
