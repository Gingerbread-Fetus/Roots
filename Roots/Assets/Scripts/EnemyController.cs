using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    [SerializeField] GameObject[] dropOnDeath;
    [SerializeField] GameObject dropHolder;
    Vector2 movement;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            movement = direction; 
        }
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            moveCharacter(movement); 
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnDestroy()
    {
        foreach(GameObject drop  in dropOnDeath)
        {
            var dropped = Instantiate(drop, gameObject.transform.position, Quaternion.identity);
            dropped.transform.parent = dropHolder.transform;
        }
    }
}
