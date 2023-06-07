using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNext : BaseButton
{
    protected override void OnClick()
    {
        UIManager.Ins.CloseUI<Win>();
        LevelManager.Ins.LoadNextLevel(); //this will be called when use press NEXT button 
        WinVFX.Ins.OnDestroy();
    }
}
