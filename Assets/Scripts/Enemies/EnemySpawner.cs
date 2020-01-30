using UnityEngine.AI;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
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

    #region Inspector Variables
    [SerializeField]
    GameObject[] l_go_EnemyPrefabs;


    [Header("SpawnLocationOnZaxis")]

    [SerializeField]
    [Range(-20, 20)]
    float f_Zmin;

    [SerializeField]
    [Range(-20, 20)]
    float f_Zmax;

    [Header("SpawnTiming")]
    [SerializeField]
    [Range(0, 20)]
    float f_Tmin;

    [SerializeField]
    [Range(1, 20)]
    float f_Tmax;

    [SerializeField]
    Transform t_EnemyTarget;

    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemies", Random.Range(f_Tmin, f_Tmax));
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Methods
    void SpawnEnemies()
    {
        float RandomZ = Random.Range(f_Zmin, f_Zmax);
        int RandomEnemy = Random.Range(0, l_go_EnemyPrefabs.Length);
        Vector3 EnemyPos = new Vector3(transform.localPosition.x + 3, transform.localPosition.y, transform.localPosition.z + RandomZ);
        GameObject NewEnemy = Instantiate(l_go_EnemyPrefabs[RandomEnemy], EnemyPos, new Quaternion(0,0,0,0));
        NewEnemy.transform.SetParent(transform);
        NewEnemy.GetComponent<NavMeshAgent>().SetDestination(t_EnemyTarget.position);
        NewEnemy.GetComponent<EnemyController>().t_Target = t_EnemyTarget;

        float Delay = Random.Range(f_Tmin, f_Tmax);

        Invoke("SpawnEnemies", Delay);
    }
    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines
    #endregion
}
