

using TMPro;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    #region Singleton

    #endregion

    #region Variables

    #region Booleans
    bool IsAbsorbing;
    bool IsAlive;
    #endregion

    #region Vectors And Transforms
    Vector3 rotation;
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
        rotation = new Vector3(0, 1, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (i_LifePoints >= 100 && !IsAlive)
        {
            transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material = mat_LifeMaterial;
            GameManager._PlanetsSurvived++;
            IsAlive = true;

        }


        if (i_LifePoints>= 100)
        {
            transform.GetChild(2).Rotate(rotation);
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
