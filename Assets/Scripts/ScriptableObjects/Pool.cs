using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewPool", menuName = "Pool", order = 1)]
public class Pool : ScriptableObject
{
    [SerializeField]
    int i_PoolAmount;
    [SerializeField]
    GameObject go_ObjectPrefab;
    [HideInInspector]
    public Queue<GameObject> l_ObjectPool;


    public void InitializePool()
    {
        l_ObjectPool = new Queue<GameObject>();
        GameObject go_ParentObject = new GameObject(go_ObjectPrefab.name + "Parent");
        for (int i = 0; i < i_PoolAmount; i++)
        {
            GameObject obj = Instantiate(go_ObjectPrefab, go_ParentObject.transform);
            obj.SetActive(false);
            l_ObjectPool.Enqueue(obj);
        }
    }


    public void SpawnFromPool(Transform spawner, int speed)
    {
        GameObject obj = l_ObjectPool.Dequeue();

        obj.SetActive(true);
        obj.transform.position = spawner.position;
        obj.transform.rotation = spawner.rotation;
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.WakeUp();
        rb.AddForce(spawner.forward * speed);
        
       
        l_ObjectPool.Enqueue(obj);


    }


    public void SpawnDoubleShoot(Transform spawner1, Transform spawner2, int speed)
    {
        GameObject obj1 = l_ObjectPool.Dequeue();
        GameObject obj2 = l_ObjectPool.Dequeue();

        obj1.SetActive(true);
        obj1.transform.position = spawner1.position;
        obj1.transform.rotation = spawner1.rotation;
        Rigidbody rb1 = obj1.GetComponent<Rigidbody>();
        rb1.WakeUp();
        rb1.AddForce(spawner1.forward * speed);

        obj2.SetActive(true);
        obj2.transform.position = spawner2.position;
        obj2.transform.rotation = spawner2.rotation;
        Rigidbody rb2 = obj2.GetComponent<Rigidbody>();
        rb2.WakeUp();
        rb2.AddForce(spawner2.forward * speed);

        l_ObjectPool.Enqueue(obj2);
    }


    public void ThrowIntoPool(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = new Vector3();
        obj.GetComponent<Rigidbody>().Sleep();
    }


    public void DestroyAfterRange(GameObject obj, Vector3 startPosition, int range)
    {
        if (Vector3.Distance(startPosition, obj.transform.position) >= range)
        {
            ThrowIntoPool(obj);
        }
    }
}
