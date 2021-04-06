using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShootObject : MonoBehaviour
{
    public string[] objectTag;
    private void Start()
    {
        InvokeRepeating(nameof(ObjectShooter),0.5f,0.015f);
    }

    private void ObjectShooter()
    {
        var bullet = ObjectPooler.sharedInstance.GetPooledObject(objectTag[0]); 
            if (bullet != null) {
                var transformCenter = transform;
                bullet.transform.position = transformCenter.position;
                bullet.transform.rotation = transformCenter.rotation;
                bullet.SetActive(true);
            }
    }
}
