using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int poolSize = 20;

    List<GameObject> pool;

    void Awake()
    {
        if (prefab == null)
        {
            Debug.LogError("###ObjectPool### Prefab não atribuido");
            return;
        }

        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject Get()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i] == null)
            {
                pool.RemoveAt(i);
                i--;
                continue;
            }

            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }

        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }
}
