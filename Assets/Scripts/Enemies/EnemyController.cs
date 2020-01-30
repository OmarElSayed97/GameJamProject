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

    #endregion

    #region Vectors And Transforms
    [HideInInspector]
    public Transform t_Target;
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {

            agt_CurrentAgent.enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }
    #endregion

    #region Coroutines

  
    #endregion
}
