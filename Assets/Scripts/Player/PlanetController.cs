using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    #region Singleton

    #endregion

    #region Variables

    #region Booleans
    bool IsAbsorbing;
    #endregion

    #region Vectors And Transforms

    #endregion

    #region Integers And Floats
    [HideInInspector]
    public int i_LifePoints;
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
    public TextMeshPro planetText;
    #endregion

    #region Others
    [SerializeField]
    Material mat_LifeMaterial;
    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(i_LifePoints >= 100)
        {
           transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material = mat_LifeMaterial;
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
