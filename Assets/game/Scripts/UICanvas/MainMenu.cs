using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : UICanvas
{
    public override void Open()
    {
        base.Open();
        LevelManager.Ins.DestroyCurrentLevel();
    }
}
