using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{
    [SerializeField] private float explosionDelay = 3f; 
    [SerializeField] private float explosionRadius = 6f;
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
        }

        
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
