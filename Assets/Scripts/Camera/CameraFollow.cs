using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    #region Singleton

    #endregion

    #region Variables

    #region Booleans

    #endregion

    #region Vectors And Transforms
    [SerializeField]
    Transform t_Target;
    [SerializeField]
    Vector3 v_CameraOffset;
    #endregion

    #region Integers And Floats
    [SerializeField]
    float f_SmoothSpeed;
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
        RotateSkybox(2f);
    }

    void LateUpdate()
    {
        FollowPlayer();
    }
    #endregion

    #region Methods

    void FollowPlayer()
    {
        
        Vector3 v_CameraFinalPos = t_Target.position + v_CameraOffset;
        //Vector3 v_SmoothedPos = Vector3.Lerp(transform.position, v_CameraFinalPos, f_SmoothSpeed );
        transform.position = v_CameraFinalPos;

        transform.LookAt(t_Target);
    }

    void RotateSkybox(float speed)
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);
    }
    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines
    #endregion

   

   

   

   
}