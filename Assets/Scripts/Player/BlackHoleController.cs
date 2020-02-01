using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

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

   

    #endregion

    private void AttractEnemies()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 4f);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].CompareTag("Enemy") )
            {
                NavMeshAgent enemyAgent = hitColliders[i].GetComponent<NavMeshAgent>();
                string originalTag = hitColliders[i].tag;
                hitColliders[i].tag = "EnemyAttracted";
                enemyAgent.enabled = false;
                
                Transform part = hitColliders[i].transform;
                part.position = Vector3.MoveTowards(part.position, transform.position, 2f * Time.deltaTime);
                
                hitColliders[i].tag = originalTag;
                enemyAgent.enabled = true;

                RaycastHit hit;
                if (Physics.Raycast(hitColliders[i].transform.position , Vector3.down, out hit, 1f))
                {
                    if (hit.collider.name == "Plane")
                    {
                        hitColliders[i].GetComponent<Collider>().enabled = false;
                        enemyAgent.enabled = false;
                    }
                }
            }
            else if (hitColliders[i].CompareTag("EnemyParts"))
            {
                Transform part = hitColliders[i].transform;
                part.position = Vector3.MoveTowards(part.position, transform.position, 2f * Time.deltaTime);
            }
        }
    }
    
    #region Collisons And Triggers

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyParts"))
        {
            int life = int.Parse(GameManager._LifeSource.text);
            life += 5;
            GameManager._LifeSource.text = life + "";
            Destroy(other.gameObject);
        }
    }
    #endregion

    #region Coroutines
    #endregion

}
