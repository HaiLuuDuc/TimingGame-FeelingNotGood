using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContinueInSettings : BaseButton
{
    protected override void OnClick()
    {
        Time.timeScale = 1f;
        UIManager.Ins.CloseUI<Settings>();
    }
}
