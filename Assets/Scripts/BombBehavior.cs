using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEditor;


public class BombBehavior : MonoBehaviour
{
    [SerializeField] private float explosionDelay = 3f; 
    [SerializeField] private float explosionRadius;
    [SerializeField] private LayerMask destructibleLayer; 

    void Start()
    {
        
        Invoke("Explode", explosionDelay);
    }

    void Explode()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, destructibleLayer);

       
        foreach (Collider2D hit in hits)
        {
            Destroy(hit.gameObject); 

            if (hit.gameObject.CompareTag("Player"))
            {
                FindObjectOfType<RespawnManager>().SpawnPlayerIfNeeded();
            }
        }

        Destroy(gameObject);
    }
}

