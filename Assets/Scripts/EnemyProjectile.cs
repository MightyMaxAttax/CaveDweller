using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float speed;

  
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerController.playerHealth -= 1;
            Destroy(gameObject);
        }

        else if (col.gameObject.tag == "Walls")
        {
            Destroy(gameObject);
        }

        else if (col.gameObject.tag == "Obstacles")
        {
            Destroy(gameObject);
        }

    }
   
}
