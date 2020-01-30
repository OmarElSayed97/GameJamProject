
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    [SerializeField]
    Pool BulletPool;

    private Vector3 v_StartPos;
    // Start is called before the first frame update
    void Start()
    {
        v_StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        BulletPool.DestroyAfterRange(gameObject, v_StartPos, 50);
    }
}
