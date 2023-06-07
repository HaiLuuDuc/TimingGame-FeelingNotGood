using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guideline : MonoBehaviour
{
    private bool isClicked = false;
    void Update()
    {
        if (isClicked) return;
        if(Input.GetMouseButtonDown(0) && !UI_HoverTest.Ins.IsPointerOverUIElement())
        {
            this.gameObject.SetActive(false);
            isClicked = true;
        }

    }
}
