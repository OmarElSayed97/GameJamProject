using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class BlackHoleController : MonoBehaviour
{
    #region Singleton

    #endregion

    #region Variables

    #region Booleans

    private bool isEmitting;

    #endregion

    #region Vectors And Transforms

    #endregion

    #region Integers And Floats

    private int i_PlayerLife;
    private int i_PlanetLife;


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
        GiveLife();
    }
    #endregion

    #region Methods
    private void AttractEnemies()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 8f);

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

                //RaycastHit hit;
                //if (Physics.Raycast(hitColliders[i].transform.position , Vector3.down, out hit, 1f))
                //{
                //    if (hit.collider.name == "Plane")
                //    {
                //        hitColliders[i].GetComponent<Collider>().enabled = false;
                //        enemyAgent.enabled = false;
                //    }
                //}
            }
            else if (hitColliders[i].CompareTag("EnemyParts"))
            {
                Transform part = hitColliders[i].transform;
                part.position = Vector3.MoveTowards(part.position, transform.position, 4f * Time.deltaTime);
            }
        }
    }

    private void GiveLife()
    {
       
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5f);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].CompareTag("Planet"))
            {
               
                PlanetController Planet = hitColliders[i].gameObject.GetComponent<PlanetController>();
                
                Planet.planetText.text = Planet.i_LifePoints + "%";
                if (!isEmitting)
                {
                    StartCoroutine(WaitWhileEmitting(Planet));
                }
            }
        }
    }

    #endregion

   
    
    #region Collisons And Triggers

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyParts"))
        {   
            if(GameManager._LifeSource >= 100)
            {
                GameManager._LifeSource = 100;
            }
            else
            {
               
                GameManager._LifeSource += 5;
                Destroy(other.gameObject);
            }
        }
    }
    #endregion

    #region Coroutines

    IEnumerator WaitWhileEmitting(PlanetController planet)
    {
        isEmitting = true;
        yield return new WaitForSeconds(0.1f);
        if (GameManager._LifeSource >= 5 && planet.i_LifePoints < 100)
        {
            planet.i_LifePoints += 5;
            GameManager._LifeSource -= 5;
        }
        planet.planetText.text = planet.i_LifePoints + "%";
        isEmitting = false;
    }
    #endregion

}
