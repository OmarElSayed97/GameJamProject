using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBubble : MonoBehaviour
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
    #endregion

    #region Others
    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyPowerUp", 2f);
    }

   
   
    #endregion

    #region Methods
    void DestroyPowerUp()
    {
        Destroy(gameObject);
    }
    #endregion

    #region Collisons And Triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            UIManager._f_TimeLeft+=5;
            Destroy(gameObject);
        }
    }
    #endregion

    #region Coroutines
    #endregion
}
