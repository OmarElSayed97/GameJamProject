
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
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
    private GameObject go_PauseMenuCanvas;
    #endregion

    #region Private GameObjects
    #endregion

    #region UIElements
    #endregion

    #region Others
    #endregion

    #endregion


    #region Main Methods

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            if (go_PauseMenuCanvas.activeSelf)
            {
                Time.timeScale = 1;
                go_PauseMenuCanvas.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                go_PauseMenuCanvas.SetActive(true);
            }
            
            
        }
    }

    #endregion

    #region Methods

    public void onClickResume()
    {
        go_PauseMenuCanvas.SetActive(false);
            Time.timeScale = 1;
    }
    
    public void onClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void onClickQuitToMainMenu(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
        Time.timeScale = 1;
    }
    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines
    #endregion
}
