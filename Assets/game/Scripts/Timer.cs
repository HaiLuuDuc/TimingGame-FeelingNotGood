using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : Singleton<Timer>
{
    [SerializeField] private TextMeshProUGUI min;
    [SerializeField] private TextMeshProUGUI sec;
    [SerializeField] private TextMeshProUGUI milisec;
    public float timer;


    private void Update()
    {
        if(LevelManager.Ins.currentLevel == null)
        {
            return;
        }

        if (LevelManager.Ins.currentLevel.isSetUp == false)
        {
            return;
        }

        this.timer = LevelManager.Ins.currentLevel.timer;

        int milisecond = (int)(timer*100%100/100 * 60); 
        int second = (int)timer % 60;
        int minute = (int)timer / 60;

        if (second < 10)
        {
            sec.text = "0" + second.ToString();
        }
        else
        {
            sec.text = second.ToString();
        }

        if (milisecond < 10)
        {
            milisec.text = "0" + milisecond.ToString();
        }
        else
        {
            milisec.text = milisecond.ToString();
        }

        if (minute < 10)
        {
            min.text = "0" + minute.ToString();
        }
        else
        {
            min.text = minute.ToString();
        }
    }

}