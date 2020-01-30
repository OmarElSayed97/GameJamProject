using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenLoaderManager : MonoBehaviour
{
    #region Singleton

    #endregion

    #region Variables

    #region Booleans

    #endregion

    #region Vectors And Transforms

    #endregion

    #region Integers And Floats

    [SerializeField] private int SceneIndex;
    #endregion

    #region Strings And Enums
    #endregion

    #region Lists
    #endregion

    #region Public GameObjects

    [SerializeField]
    private GameObject go_LoadingScreenCanvas;
    #endregion

    #region Private GameObjects
    #endregion

    #region UIElements
    [SerializeField]
    private Slider ui_LoadingSlider;

    [SerializeField] 
    private TextMeshProUGUI ui_SliderText;
    #endregion

    #region Others
    #endregion

    #endregion


    #region Main Methods

    private void Awake()
    {
        StartCoroutine(LoadScene(SceneIndex));
    }

    #endregion

    #region Methods
    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines

    IEnumerator LoadScene(int SceneIndex)
    {
        AsyncOperation operation =  SceneManager.LoadSceneAsync(SceneIndex);
        
        go_LoadingScreenCanvas.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            ui_LoadingSlider.value = progress;
            ui_SliderText.text = ui_LoadingSlider.value * 100 + "%";
            yield return null;
        }
    }
    #endregion
}
