using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSettings : BaseButton
{
    protected override void OnClick()
    {
        Time.timeScale = 0f;
        UIManager.Ins.OpenUI<Settings>();
    }
}
