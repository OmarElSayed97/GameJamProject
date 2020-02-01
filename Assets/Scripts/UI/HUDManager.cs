using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
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
    #endregion

    #region Private GameObjects
    #endregion

    #region UIElements

    [SerializeField] 
    private Sprite[] ui_SpaceShipeInspector;

    private static Sprite[] ui_SpaceShipSprites;
    #endregion

    #region Others
    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ui_SpaceShipeInspector.Length; i++)
        {
            ui_SpaceShipSprites[i] = ui_SpaceShipeInspector[i];
        }
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Methods
    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines
    #endregion
}
