using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandBasketball : MonoBehaviour
{
    [SerializeField] private Transform ball;
    public float delayTime;
    public Vector3 offset;
    private bool isClicked = false;

    private void Update()
    {
        if (isClicked == false && Input.GetMouseButtonDown(0) && !UI_HoverTest.Ins.IsPointerOverUIElement())
        {
            StartCoroutine(FollowBallCoroutine(delayTime));
            isClicked = true;
        }
    }


    public IEnumerator FollowBallCoroutine(float delayTime)
    {
        float elapsedTime = 0f;
        float duration = delayTime;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            Cache.GetTransform(this.gameObject).position = ball.position + offset;
            yield return null;
        }
        yield return null;
    }
}
