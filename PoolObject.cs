using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public float lifeTime = 4f;
    
    private void OnEnable () {
        StartCoroutine(Disabler());
    }
    private IEnumerator Disabler()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

}
