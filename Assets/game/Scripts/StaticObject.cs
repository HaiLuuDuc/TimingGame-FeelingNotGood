using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class StaticObject : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite fitSprite;
    public Transform TF;
    public Transform fitTF;
    public Vector3 offsetPos;
    public Vector3 offsetRot;
    public Vector3 offsetScale;

    public void OnWin()
    {
        if(fitSprite != null)
        {
            spriteRenderer.sprite = fitSprite;
        }
        TF.position = fitTF.position + offsetPos;
        TF.rotation = fitTF.rotation;
        TF.localScale = fitTF.localScale + offsetScale;
        StartCoroutine(OnWinCoroutine());
    }

    public IEnumerator OnWinCoroutine()
    {
        while(true)
        {
            TF.position = fitTF.position + offsetPos;
            TF.rotation = fitTF.rotation * Quaternion.Euler(offsetRot);
            TF.localScale = fitTF.localScale + offsetScale;
            yield return null;
        }
        yield return null;
    }

}
