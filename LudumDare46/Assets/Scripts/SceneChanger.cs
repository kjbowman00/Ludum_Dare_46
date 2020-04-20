using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject blackScreen;
    public float maxSizeLoadBar;
    public GameObject loadBar;
    public static SceneChanger instance;
    public GameObject loadingScreen;

    private RectTransform loadBarT;

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    private void Awake()
    {
        loadBarT = loadBar.GetComponent<RectTransform>();
        instance = this;
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive); // Load main menu
    }

    public void LoadIntro()
    {
        MusicTime.instance.stopMusic();
        loadingScreen.SetActive(true);
        scenesLoading.Add(SceneManager.UnloadSceneAsync(1)); //Get rid of main menu
        scenesLoading.Add(SceneManager.LoadSceneAsync(5, LoadSceneMode.Additive)); //Load baby room

        StartCoroutine(GetSceneLoadProgress());
    }

    public void LoadGame()
    {
        MusicTime.instance.playMusic();
        loadingScreen.SetActive(true);
        scenesLoading.Add(SceneManager.UnloadSceneAsync(5)); //Get rid of intro
        scenesLoading.Add(SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive)); //Load baby room

        StartCoroutine(GetSceneLoadProgress());
    }

    public IEnumerator GetSceneLoadProgress()
    {
        foreach(AsyncOperation currentScene in scenesLoading)
        {
            float size = currentScene.progress * maxSizeLoadBar;
            loadBarT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
            while (!currentScene.isDone) yield return null;
        }

        loadingScreen.SetActive(false);
        scenesLoading.Clear();
    }

    public void toMenu(int sceneNum)
    {
        loadingScreen.SetActive(true);
        scenesLoading.Add(SceneManager.UnloadSceneAsync(sceneNum));
        scenesLoading.Add(SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress());
    }

    public void winGame()
    {
        blackScreen.SetActive(true);
        SceneManager.UnloadSceneAsync(2);
        SceneManager.LoadSceneAsync(4, LoadSceneMode.Additive);

        StartCoroutine(winGameWait());
    }

    private IEnumerator winGameWait()
    {
        yield return new WaitForSeconds(0.2f);

        blackScreen.SetActive(false);
    }

    public void loseGame()
    {
        blackScreen.SetActive(true);
        SceneManager.UnloadSceneAsync(2);
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);

        StartCoroutine(loseGameWait());
    }

    private IEnumerator loseGameWait()
    {
        yield return new WaitForSeconds(1.2f);

        BossLose.begin = true;
        blackScreen.SetActive(false);
    }
}
