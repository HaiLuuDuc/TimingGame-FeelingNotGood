using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upper : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        HideSpriteRenderer();
    }

    public void ShowSpriteRenderer()
    {
        spriteRenderer.enabled = true;
    }

    public void HideSpriteRenderer()
    {
        spriteRenderer.enabled = false;
    }
}
