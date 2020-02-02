using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    #region Singleton

    #endregion

    #region Variables

    #region Booleans
    bool IsStaying;
    #endregion

    #region Vectors And Transforms
    [HideInInspector]
    public Transform t_Target;
    #endregion

    #region Integers And Floats
    private int i_BulletsTaken = 0;
    #endregion

    #region Strings And Enums
    #endregion

    #region Lists
    #endregion

    #region Public GameObjects
    [SerializeField]
    GameObject go_LifeSource;

    #endregion

    #region Private GameObjects
    #endregion

    #region UIElements
    #endregion

    #region Others
    NavMeshAgent agt_CurrentAgent;
    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        agt_CurrentAgent = GetComponent<NavMeshAgent>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agt_CurrentAgent.enabled)
        {
            agt_CurrentAgent.SetDestination(t_Target.position);
        }
       
    }
    #endregion

    #region Methods
    #endregion

    #region Collisons And Triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            i_BulletsTaken++;
            
        }
        if(i_BulletsTaken == 2)
        {
            GameObject obj = Instantiate(go_LifeSource, transform.position + new Vector3(0, 3f,0), Quaternion.identity);
            if (IsStaying)
            {
                PlayerController.i_EnemyHitting--;
            }
            Destroy(gameObject);
            IsStaying = false;
        }
       
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            IsStaying = true;
    }


    #endregion

    #region Coroutines


    #endregion
}
