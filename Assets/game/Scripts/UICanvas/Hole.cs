using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.DEATH_ZONE) || collision.CompareTag(Constant.WIN_ZONE))
        {
            ShowSpriteRenderer();
        }
    }
}
