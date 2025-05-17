using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public float lifeTime = 5f; 

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnDestroy()
    {

    }
}
