using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTwo : MonoBehaviour
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
    //[SerializeField] 
    //private GameObject go_LifeSourceGO;
    [SerializeField]
    private GameObject go_GameOverPanel;

    [SerializeField]
    private GameObject go_Player;


    public static int _PlanetsSurvived;
    public static int _LifeSource;
    #endregion

    #region Private GameObjects
    #endregion

    #region UIElements


    #endregion

    #region Others
    GeneralAudioManager AudioManager;
    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {

        AudioManager = GetComponent<GeneralAudioManager>();
        AudioManager.Play("MainOst");
        _LifeSource = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!go_Player.gameObject.activeSelf || go_Player.transform.position.y < -50)
        {
            go_GameOverPanel.SetActive(true);

        }
    }
    #endregion

    #region Methods
    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines
    #endregion
}
