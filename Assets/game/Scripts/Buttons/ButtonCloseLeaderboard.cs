using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCloseLeaderboard : BaseButton
{
    protected override void OnClick()
    {
        Leaderboard.instance.EffectClose();
    }
}
