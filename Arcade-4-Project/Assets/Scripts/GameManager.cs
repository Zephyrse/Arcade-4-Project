using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")] 
    private static GameManager _instance;
    public GameObject loadingScreen;
    public GameObject menus;

    private readonly List<GameObject> _lMenus = new List<GameObject>();
    private readonly List<AsyncOperation> _lScenes = new List<AsyncOperation>();

    private void Awake()
    {
        // Setting the scene to be static so it isn't destroyed upon loading another scene
        _instance = this;
        _lMenus.Add(menus);
        SceneManager.LoadSceneAsync((int)SceneIndex.TITLE_SCREEN, LoadSceneMode.Additive);
    }

    public void LoadGame()
    {
        loadingScreen.gameObject.SetActive(true);
        foreach (var t in _lMenus)
        {
            t.SetActive(false);
        };

        _lScenes.Add(SceneManager.UnloadSceneAsync((int)SceneIndex.TITLE_SCREEN));
        _lScenes.Add(SceneManager.LoadSceneAsync((int)SceneIndex.FIRST_LEVEL, LoadSceneMode.Additive));

        Destroy(menus);
        StartCoroutine(SceneLoadingProgress());
    }

    private IEnumerator SceneLoadingProgress()
    {
        foreach (var t in _lScenes)
        {
            while (!t.isDone)
            {
                yield return null;
            }
        }

        loadingScreen.gameObject.SetActive(false);
    }
}
