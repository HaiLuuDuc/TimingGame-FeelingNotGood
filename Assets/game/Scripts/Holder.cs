using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Holder : MonoBehaviour
{
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;
    [SerializeField] private float openHandRange;
    [SerializeField] private float openHandDuration;
    private bool isClicked = false;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && isClicked== false && !UI_HoverTest.Ins.IsPointerOverUIElement())
        {
            OpenHands();
            isClicked = true;
        }
    }
    public void OpenHands()
    {
        leftHand
            .DOLocalMoveX(leftHand.localPosition.x - openHandRange, openHandDuration, false)
            .SetEase(Ease.OutSine);
        rightHand
            .DOLocalMoveX(rightHand.localPosition.x + openHandRange, openHandDuration, false)
            .SetEase(Ease.OutSine);
    }
}
