using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Singleton

    #endregion

    #region Variables

    #region Booleans
    private bool IsLerping;
    #endregion

    #region Vectors And Transforms
    [SerializeField]
    Transform t_Player;

    [SerializeField]
    Transform t_Level2SpawnPoint;

    [SerializeField]
    Transform t_Level3SpawnPoint;
    #endregion

    #region Integers And Floats
    private float f_TimeStartedLerping;
    private float f_TimeTakenDuringLerp = 5;


    public static float _f_TimeLeft;
    public static int _i_EnemiesLeft = 3;

    private int CurrentLevel = 1;
    #endregion

    #region Strings And Enums

    #endregion

    #region Lists
    #endregion

    #region Public GameObjects
   
    #endregion

    #region Private GameObjects
    #endregion

    #region UIElements
    [SerializeField]
    TextMeshProUGUI ui_TimeLeft;
    [SerializeField]
    TextMeshProUGUI ui_EnemiesLeft;
    #endregion

    #region Others
    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        _f_TimeLeft = 180;
    }

    // Update is called once per frame
    void Update()
    {
        _f_TimeLeft -= Time.deltaTime;
        ui_TimeLeft.text = "Time Left: " + (int)_f_TimeLeft;
        ui_EnemiesLeft.text = "EnemiesLeft: " + _i_EnemiesLeft;

        //if(_i_EnemiesLeft == 0 && CurrentLevel == 1)
        //{
        //    StartLerping();
        //    CurrentLevel++;
        //}

    }

    private void FixedUpdate()
    {
        if (IsLerping)
        {
            float timeSinceStarted = Time.time - f_TimeStartedLerping;
            float percentageCompleted = timeSinceStarted / f_TimeTakenDuringLerp;

            t_Player.position = Vector3.Lerp(t_Player.position, t_Level2SpawnPoint.position, percentageCompleted);

           
            if (percentageCompleted >= 1.0f)
            {
                IsLerping = false;
            }
        }
    }
    #endregion

    #region Methods

    void StartLerping()
    {
        IsLerping = true;
        f_TimeStartedLerping = Time.time;

    
    }
    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines
    #endregion
}
