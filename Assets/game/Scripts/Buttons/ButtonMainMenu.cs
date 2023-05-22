using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMainMenu : BaseButton
{
    protected override void OnClick()
    {
        Time.timeScale = 1f;
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<MainMenu>();
    }
}
