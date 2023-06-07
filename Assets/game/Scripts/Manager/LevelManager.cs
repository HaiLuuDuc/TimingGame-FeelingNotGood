using System.Collections;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Transform parent;
    public Level[] levels;
    public Level currentLevel;
    public int currentLevelIndex = 0;


    public void LoadLevel(int levelIndex)
    {
        DestroyCurrentLevel();
        currentLevel = Cache.GetLevel(Instantiate(levels[levelIndex].gameObject));
        Cache.GetTransform(currentLevel.gameObject).SetParent(parent);
        currentLevel.gameObject.SetActive(true);
        currentLevel.EffectInstantiate();
        currentLevelIndex = levelIndex;
    }

    public void DestroyCurrentLevel()
    {
        if (currentLevel != null)
        {
            if (currentLevelIndex == levels.Length - 1)
            {
                Destroy(currentLevel.gameObject);
            }
            else
            {
                currentLevel.EffectDestroy();
            }
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadNextLevelCoroutine());
    }

    public IEnumerator LoadNextLevelCoroutine()
    {
        yield return new WaitForSeconds(0f);
        if (currentLevelIndex < levels.Length - 1)
        {
            currentLevelIndex++;
            LoadLevel(currentLevelIndex);
            Gameplay.instance.OnWin();
        }
        else
        {
            UIManager.Ins.CloseAll();
            UIManager.Ins.OpenUI<MainMenu>();
        }
        yield return null;
    }
    

    
}
