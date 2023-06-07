using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lose : UICanvas
{
    [SerializeField] private TextMeshProUGUI youPassedLevels;
    public override void Open()
    {
        base.Open();
        youPassedLevels.text = "You passed " + LevelManager.Ins.currentLevelIndex + " levels";
    }
}
