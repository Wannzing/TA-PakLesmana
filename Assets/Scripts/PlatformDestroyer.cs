using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public float lifeTime = 5f;
    public GameObject explosionEffect;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnDestroy()
    {
        if (explosionEffect != null)
        {
            AudioManager.Instance.PlaySFX("PlatformBreak");
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
    }
}
