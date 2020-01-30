using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
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

    }
    #endregion

    #region Methods
    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 OriginCamPos = transform.localPosition;
        float TimeElapsed = 0f;

        while (TimeElapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, OriginCamPos.z);

            TimeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = OriginCamPos;

    }
    #endregion

}
