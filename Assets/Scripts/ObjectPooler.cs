﻿using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler s_SharedInstance;
    public List<GameObject> PooledObjects;
    public GameObject ObjectToPool;
    public int AmountToPool;

    void Awake()
    {
        s_SharedInstance = this;
    }

    void Start()
    {
        // Loop through list of pooled objects,deactivating them and adding them to the list 
        PooledObjects = new List<GameObject>();
        for (int i = 0; i < AmountToPool; i++)
        {
            GameObject obj = Instantiate(ObjectToPool);
            obj.SetActive(false);
            PooledObjects.Add(obj);
            obj.transform.SetParent(this.transform); // set as children of Spawn Manager
        }
    }

    public GameObject GetPooledObject()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < PooledObjects.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }
        // otherwise, return null   
        return null;
    }
}