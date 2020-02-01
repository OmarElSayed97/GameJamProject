using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
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
    private GameObject go_LifeSourceGO;

    public static TextMeshProUGUI _LifeSource;
    #endregion

    #region Private GameObjects
    #endregion

    #region UIElements

    
    #endregion

    #region Others
    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        _LifeSource = go_LifeSourceGO.GetComponent<TextMeshProUGUI>();
        _LifeSource.text = 0 + "";
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
