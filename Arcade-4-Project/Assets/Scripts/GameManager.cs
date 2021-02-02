using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public static GameManager instance;
    public GameObject loadingScreen;
    public GameObject menus;

    List<GameObject> m_Menus = new List<GameObject>();
    List<AsyncOperation> m_Scenes = new List<AsyncOperation>();

    private void Awake()
    {
        // Setting the scene to be static so it isn't destroyed upon loading another scene
        instance = this;
        m_Menus.Add(menus);
        SceneManager.LoadSceneAsync((int)SceneIndex.TITLE_SCREEN, LoadSceneMode.Additive);
    }

    public void LoadGame()
    {
        loadingScreen.gameObject.SetActive(true);
        foreach (var t in m_Menus)
        {
            t.SetActive(false);
        };

        m_Scenes.Add(SceneManager.UnloadSceneAsync((int)SceneIndex.TITLE_SCREEN));
        m_Scenes.Add(SceneManager.LoadSceneAsync((int)SceneIndex.FIRST_LEVEL, LoadSceneMode.Additive));

        Destroy(menus);
        StartCoroutine(SceneLoadingProgress());
    }

    private IEnumerator SceneLoadingProgress()
    {
        foreach (var t in m_Scenes)
        {
            while (!t.isDone)
            {
                yield return null;
            }
        }

        loadingScreen.gameObject.SetActive(false);
    }
}
