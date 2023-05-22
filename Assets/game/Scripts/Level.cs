using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Level : MonoBehaviour
{
    [SerializeField] private Move move;
    public float timer;
    public bool isLaunched;
    public bool isSetUp;

    private void Start()
    {
        isLaunched = false;
        isSetUp = false;
    }


    private void Update()
    {
        if (isLaunched == false)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                isLaunched = true;
            }
        }
    }

    public void StartTimer()
    {
        timer = 0;
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        while(isLaunched == false)
        {
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public void EffectDestroy()
    {
        Cache.GetTransform(this.gameObject)
            .DOLocalMove(Cache.GetTransform(this.gameObject).position - new Vector3(11, 0, 0), 1f, false)
            .SetEase(Ease.InOutQuart)
            .OnComplete(() =>
            {
                Destroy(this.gameObject);
            })
            ;
    }

    public void EffectInstantiate()
    {
        Cache.GetTransform(this.gameObject)
            .DOLocalMove(Cache.GetTransform(this.gameObject).position + new Vector3(11, 0, 0), 1f, false)
            .SetEase(Ease.InOutQuart)
            .From()
            .OnComplete(() =>
            {
                move.OnInit();
                LevelManager.Ins.currentLevel.StartTimer();
                LevelManager.Ins.currentLevel.isSetUp = true;
            })
            ;
    }
}
