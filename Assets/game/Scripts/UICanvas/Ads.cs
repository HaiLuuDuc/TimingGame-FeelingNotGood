using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ads : UICanvas
{
    public static Ads instance;
    private void Awake()
    {
        instance = this;
    }

    public IEnumerator CloseAfter(float time)
    {
        yield return new WaitForSeconds(time);
        UIManager.Ins.CloseUI<Ads>();
    }
}
