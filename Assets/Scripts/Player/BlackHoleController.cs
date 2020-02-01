using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleController : MonoBehaviour
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
       
    }

    // Update is called once per frame
    void Update()
    {
        AttractEnemies();
    }
    #endregion

    #region Methods

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyParts"))
        {
            Destroy(other.gameObject);
        }
    }

    #endregion

    private void AttractEnemies()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 4f);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].CompareTag("EnemyParts") || hitColliders[i].CompareTag("Enemy") )
            {
                
                Transform part = hitColliders[i].transform;
                part.position = Vector3.MoveTowards(part.position, transform.position, 2f * Time.deltaTime);
            }
        }
    }
    #region Collisons And Triggers
    #endregion

    #region Coroutines
    #endregion

}
