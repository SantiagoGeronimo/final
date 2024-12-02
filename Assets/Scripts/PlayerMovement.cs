using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] GameObject bombPrefab; 
    [SerializeField] Transform bombSpawnPoint;
    [SerializeField] float bombCD = 3f;
    private bool canPlaceBomb = true;
    private Vector2 movement; 

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        if (Input.GetKeyDown(KeyCode.Space) && canPlaceBomb)
        {
            PlaceBomb();
        }
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);

        RaycastHit2D hit = Physics2D.Raycast(rb.position, movement, moveSpeed * Time.fixedDeltaTime);

        if (hit.collider == null)
        {
            rb.MovePosition(newPosition);
        }
        
    }

    void PlaceBomb()
    {
        Instantiate(bombPrefab, bombSpawnPoint.position, Quaternion.identity);
        StartCoroutine(BombCooldownRoutine());
    }

    private IEnumerator BombCooldownRoutine()
    {
        canPlaceBomb = false; 
        yield return new WaitForSeconds(bombCD); 
        canPlaceBomb = true; 
    }
}
