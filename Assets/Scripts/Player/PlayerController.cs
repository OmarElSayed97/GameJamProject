using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using  UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Singleton

    #endregion

    #region Variables

    #region Booleans
    private bool IsTeleporting;
    #endregion

    #region Vectors And Transforms
    [SerializeField]
    Transform t_BulletSpawner1;
    [SerializeField]
    Transform t_BulletSpawner2;
    #endregion

    #region Integers And Floats
    public static int i_EnemyHitting = 0;
    [SerializeField] 
    private float f_BlackholeOffset;

    private float f_TeleportOffsetVertical;

    private int i_CurrentWeaponIndex;
   
    #endregion

    #region Strings And Enums
    enum Weapon
    {
        LASER,
        BLACKHOLE,
        TELEPORT
    }

    [SerializeField]
    Weapon CurrentWeapon;

    #endregion

    #region Lists

    Weapon[] l_Weapons;
    #endregion

    #region Public GameObjects

    [SerializeField] 
    public GameObject go_BlackHole;
    #endregion

    #region Private GameObjects

    private GameObject go_InstantiatedBlackHole;
    #endregion

    #region UIElements
    [SerializeField]
    private TextMeshProUGUI ui_LifeText;

    [SerializeField]
    Sprite[] l_sprite_AbilityIcons;
    [SerializeField]
    Image[] l_img_AbilityImages;
    #endregion

    #region Others
    [SerializeField]
    Pool BulletsPool;

    [SerializeField]
    CameraShake ShakingCamera;

    [SerializeField]
    Material mat_DissolveMaterial;

    GeneralAudioManager AudioManager;
    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Awake()
    {
        BulletsPool.InitializePool();
        //ui_LifeText.text = 0 + "";
        l_Weapons = new Weapon[3];
        l_Weapons[0] = Weapon.LASER;
        l_Weapons[1] = Weapon.BLACKHOLE;
        l_Weapons[2] = Weapon.TELEPORT;

        AudioManager = GetComponent<GeneralAudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
            if(CurrentWeapon == Weapon.LASER)
                Fire();
            if(CurrentWeapon == Weapon.BLACKHOLE)
                ReleaseBlackHole();
            if (CurrentWeapon == Weapon.TELEPORT)
                Teleport();

            SwitchWeapon();
            //NumberofEnemiesAroundPlayer();
        
      
    }
    #endregion

    #region Methods
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioManager.Play("Laser");
            BulletsPool.SpawnDoubleShoot(t_BulletSpawner1,t_BulletSpawner2, 3000);
            StartCoroutine(ShakingCamera.Shake(0.2f, 0.07f));
        }
    }

    void ReleaseBlackHole()
    {
        //TO BE CHANGED
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (!go_InstantiatedBlackHole)
            {
                AudioManager.Play("BlackHole");
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
            GetComponent<AudioSource>().Stop();
            Destroy(go_InstantiatedBlackHole);
        }
    }

    void Teleport()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100,9))
            {
                AudioManager.Play("Teleport");
                Vector3 newPos = new Vector3(hit.point.x, hit.point.y + f_TeleportOffsetVertical, hit.point.z);
                StartCoroutine(DissolveOut(newPos));
            }
        }
    }

    void StartTeleporting(Vector3 TeleportPos)
    {
        transform.position = TeleportPos;
        StartCoroutine(DissolveIn());
    }

    void SwitchWeapon()
    {
        bool IsSwitching = false;
        float wheelValue = Input.GetAxis("Mouse ScrollWheel");
        if (wheelValue > 0)
        {
            if (i_CurrentWeaponIndex == 2)
                i_CurrentWeaponIndex = 0;
            else
                i_CurrentWeaponIndex++;

            IsSwitching = true;
        }
        if (wheelValue < 0)
        {
            if (i_CurrentWeaponIndex == 0)
                i_CurrentWeaponIndex = 2;
            else
                i_CurrentWeaponIndex--;

            IsSwitching = true;
        }


        if (IsSwitching)
        {
            CurrentWeapon = l_Weapons[i_CurrentWeaponIndex];
            if (l_Weapons[i_CurrentWeaponIndex] == Weapon.LASER)
            {
                l_img_AbilityImages[1].sprite = l_sprite_AbilityIcons[0];
                l_img_AbilityImages[0].sprite = l_sprite_AbilityIcons[2];
                l_img_AbilityImages[2].sprite = l_sprite_AbilityIcons[1];

            }
            else if (l_Weapons[i_CurrentWeaponIndex] == Weapon.BLACKHOLE)
            {
                l_img_AbilityImages[1].sprite = l_sprite_AbilityIcons[1];
                l_img_AbilityImages[0].sprite = l_sprite_AbilityIcons[0];
                l_img_AbilityImages[2].sprite = l_sprite_AbilityIcons[2];

            }
            else
            {
                l_img_AbilityImages[1].sprite = l_sprite_AbilityIcons[2];
                l_img_AbilityImages[0].sprite = l_sprite_AbilityIcons[1];
                l_img_AbilityImages[2].sprite = l_sprite_AbilityIcons[0];

            }
            IsSwitching = false;
           
        }
    }


    //void NumberofEnemiesAroundPlayer()
    //{
    //    Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale/2);

    //    for (int i = 0; i < hitColliders.Length; i++)
    //    {
    //        if (hitColliders[i].CompareTag("Enemy"))
    //        {
    //            i_EnemyHitting++;
    //        }
    //    }
    //    if (hitColliders.Length >= 3 && i_EnemyHitting >= 3)
    //    {
    //        gameObject.SetActive(false);
    //    }

    //    i_EnemyHitting = 0;
    //}

    #endregion

    #region Collisons And Triggers
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            i_EnemyHitting++;
            Debug.Log("EnemyHit");
        }

        if (i_EnemyHitting == 3)
        {
            gameObject.SetActive(false);
            //ShowGameover
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
           i_EnemyHitting--;
            Debug.Log("Enemy Left");
        }
    }

   
    #endregion

    #region Coroutines
    IEnumerator DissolveIn()
    {
        float counter = 1;
        while (counter > -1)
        {
            counter -= Time.deltaTime;
            yield return new WaitForSeconds(0.005f);
            mat_DissolveMaterial.SetFloat("Vector1_7C06CC4A", counter);
        }
    }

    IEnumerator DissolveOut(Vector3 TeleportPos)
    {
        float counter = 0;
        while (counter < 1)
        {
            counter += Time.deltaTime;
            yield return new WaitForSeconds(0.005f);
            mat_DissolveMaterial.SetFloat("Vector1_7C06CC4A", counter);
        }
        StartTeleporting(TeleportPos);
    }

   
   

    #endregion








}
