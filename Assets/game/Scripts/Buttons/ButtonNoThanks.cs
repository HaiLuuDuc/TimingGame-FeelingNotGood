using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNoThanks : BaseButton
{
    protected override void OnClick()
    {
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<MainMenu>();
        CameraController.Ins.OnReset();
    }
}
