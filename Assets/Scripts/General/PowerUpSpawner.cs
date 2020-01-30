using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
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
    GameObject[] l_go_PowerUpPrefabs;


    [Header("SpawnLocationOnZaxis")]

    [SerializeField]
    [Range(-50, 50)]
    float f_Zmin;

    [SerializeField]
    [Range(-50, 50)]
    float f_Zmax;

    [Header("SpawnLocationOnZaxis")]

    [SerializeField]
    [Range(-50, 50)]
    float f_Xmin;

    [SerializeField]
    [Range(-50, 50)]
    float f_Xmax;


    [Header("SpawnTiming")]
    [SerializeField]
    [Range(0, 20)]
    float f_Tmin;

    [SerializeField]
    [Range(1, 20)]
    float f_Tmax;

   

    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnPowerUps", Random.Range(f_Tmin, f_Tmax));
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Methods
    void SpawnPowerUps()
    {
        float RandomZ = Random.Range(f_Zmin, f_Zmax);
        float RandomX = Random.Range(f_Xmin, f_Xmax);
        int RandomEnemy = Random.Range(0, l_go_PowerUpPrefabs.Length);
        Vector3 EnemyPos = new Vector3(transform.localPosition.x, transform.localPosition.y + 1, transform.localPosition.z + RandomZ);
        GameObject NewEnemy = Instantiate(l_go_PowerUpPrefabs[RandomEnemy], EnemyPos, Quaternion.identity);
        NewEnemy.transform.SetParent(transform);
        

        float Delay = Random.Range(f_Tmin, f_Tmax);

        Invoke("SpawnPowerUps", Delay);
    }
    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines
    #endregion
}
