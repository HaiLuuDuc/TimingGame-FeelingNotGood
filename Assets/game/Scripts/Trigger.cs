using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private MoveObject moveObject;
    public bool isWin = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.DEATH_ZONE))
        {
            isWin = false;
            Debug.Log("deathzone");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.DEATH_ZONE))
        {
            isWin = true;
            Debug.Log("winzone");
        }
    }

}
