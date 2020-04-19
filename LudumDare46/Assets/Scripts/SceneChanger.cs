﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
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

    public void LoadGame()
    {
        loadingScreen.SetActive(true);
        scenesLoading.Add(SceneManager.UnloadSceneAsync(1)); //Get rid of main menu
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
    }
}