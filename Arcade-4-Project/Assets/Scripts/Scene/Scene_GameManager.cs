using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// An important script that manages the loading of levels as well as some other functions
/// Loading levels in this script will be Asyncronous.
/// </summary>

public class Scene_GameManager : MonoBehaviour
{
    [Header("References")] 
    private static Scene_GameManager _instance;
    public GameObject loadingScreen;
    public GameObject menus;
    public GameObject nameEnter;
    private bool firstTime = true;

    private readonly List<GameObject> _lMenus = new List<GameObject>();
    private readonly List<AsyncOperation> _lScenes = new List<AsyncOperation>();

    private void Awake()
    {
        // Setting the scene to be static so it isn't destroyed upon loading another scene
        _instance = this;
        _lMenus.Add(menus);
        SceneManager.LoadSceneAsync((int)Misc_SceneIndex.TITLE_SCREEN, LoadSceneMode.Additive);
        CheckNameEntered();
        
    }

    private void FixedUpdate()
    {
        //PlayerController player = GetComponent<PlayerController>();

        //if (player._endLevel)
        //{
        //    player._endLevel = false;
        //    EndLevel();
        //}
        
    }

    public void CheckNameEntered()
    {
        if (firstTime == true)
        {
            nameEnter.SetActive(true);
            firstTime = false;
        }

        if (Misc_ReadString.nInput != null)
        {
            nameEnter.SetActive(false);
            menus.SetActive(true);
        }
    }

    public void LoadGame()
    {
        loadingScreen.gameObject.SetActive(true);
        foreach (var t in _lMenus)
        {
            t.SetActive(false);
        };

        _lScenes.Add(SceneManager.UnloadSceneAsync((int)Misc_SceneIndex.TITLE_SCREEN));
        _lScenes.Add(SceneManager.LoadSceneAsync((int)Misc_SceneIndex.FIRST_LEVEL, LoadSceneMode.Additive));

        Destroy(menus);
        StartCoroutine(SceneLoadingProgress());
    }

    public void LoadScoreboard()
    {
        SceneManager.LoadScene(3);
    }

    public void EndLevel()
    {
        loadingScreen.gameObject.SetActive(true);
        foreach (var t in _lMenus)
        {
            t.SetActive(false);
        };

        _lScenes.Add(SceneManager.UnloadSceneAsync((int)Misc_SceneIndex.FIRST_LEVEL));
        _lScenes.Add(SceneManager.LoadSceneAsync((int)Misc_SceneIndex.TITLE_SCREEN, LoadSceneMode.Additive));

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

    public void TestFunc()
    {

    }






}
