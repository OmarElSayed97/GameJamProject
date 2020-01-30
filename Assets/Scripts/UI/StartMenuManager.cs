using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    #region Singleton

    #endregion

    #region Variables

    #region Booleans

    #endregion

    #region Vectors And Transforms

    #endregion

    #region Integers And Floats
    #endregion

    #region Strings And Enums
    #endregion

    #region Lists
    #endregion

    #region Public GameObjects

   

    [SerializeField] 
    private GameObject go_CreditsCanvas;
    
    [SerializeField]
    private GameObject go_LoadingScreenPrefab;
    #endregion

    #region Private GameObjects
    #endregion

    #region UIElements
    #endregion

    #region Others
    #endregion

    #endregion


    #region Main Methods
    #endregion

    #region Methods
    
    public void onClickStart(int SceneIndex)
    {
        go_LoadingScreenPrefab.SetActive(true);
    }
    
    public void onClickCredits()
    {
        gameObject.SetActive(false);
        go_CreditsCanvas.SetActive(true);
    }
    public void onClickQuit()
    {
        Application.Quit();
    }
  
    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines
    #endregion
}
