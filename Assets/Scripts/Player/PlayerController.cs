using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Singleton

    #endregion

    #region Variables

    #region Booleans

    #endregion

    #region Vectors And Transforms
    [SerializeField]
    Transform t_BulletSpawner;
    #endregion

    #region Integers And Floats

    [SerializeField] 
    private float f_BlackholeOffset;
    #endregion

    #region Strings And Enums
    #endregion

    #region Lists
    #endregion

    #region Public GameObjects

    [SerializeField] 
    public GameObject go_BlackHole;
    #endregion

    #region Private GameObjects

    private GameObject go_InstantiatedBlackHole;
    #endregion

    #region UIElements
    #endregion

    #region Others
    [SerializeField]
    Pool BulletsPool;

    [SerializeField]
    CameraShake ShakingCamera;

    [SerializeField]
    Material mat_DissolveMaterial;
    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Awake()
    {
        BulletsPool.InitializePool();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        ReleaseBlackHole();
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(Dissolve());
        }
    }
    #endregion

    #region Methods
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            BulletsPool.SpawnFromPool(t_BulletSpawner, 1000);
            StartCoroutine(ShakingCamera.Shake(0.2f, 0.05f));
        }
    }

    void ReleaseBlackHole()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (!go_InstantiatedBlackHole)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray,out hit))
                {
                    Vector3 newPos = new Vector3(hit.point.x, hit.point.y + f_BlackholeOffset, hit.point.z);
                    go_InstantiatedBlackHole = Instantiate(go_BlackHole,newPos,Quaternion.identity);
                }
            }
        }
        else
        {
            Destroy(go_InstantiatedBlackHole);
        }
    }

    IEnumerator Dissolve()
    {
        float counter = 1;
        while (counter > -1)
        {
            counter -= Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
            mat_DissolveMaterial.SetFloat("Vector1_7C06CC4A", counter);
        }
    }
    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines
    
    #endregion



   


   
   
}
