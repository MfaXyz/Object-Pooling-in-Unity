using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler sharedInstance;
    
    public List<ObjectPoolItem> itemsToPool;

    public List<GameObject> pooledObjects;
    private void Awake() {
        sharedInstance = this;
    }
    void Start () {
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool) {
            for (int i = 0; i < item.amountToPool; i++) {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }
    public GameObject GetPooledObject(string tagObject) {
        foreach (var t in pooledObjects)
        {
            if (!t.activeInHierarchy && t.CompareTag(tagObject)) {
                return t;
            }
        }
        foreach (var item in itemsToPool) {
            if (item.objectToPool.CompareTag(tagObject)) {
                if (item.shouldExpand) {
                    var obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }

}
[System.Serializable]
public class ObjectPoolItem {
    public int amountToPool;
    public GameObject objectToPool;
    public bool shouldExpand;
}