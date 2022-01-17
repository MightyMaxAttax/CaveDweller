using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
   
    [SerializeField]
    private float speed;

    [SerializeField]
    private float distance;

    [SerializeField]
    private float bounceBack;

    GameObject player;

    private int damage = 1;

    private Rigidbody2D rb;

    bool bounce = false;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.name == "Player")
        {
            rb.AddForce(col.contacts[0].normal * bounceBack);
            player.GetComponent<PlayerController>().TakeDamage(damage);
            bounce = true;
            Invoke("StopBounce", 0.3f);
        }
    }

   
    void StopBounce()
    {
          bounce = false;
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            float dist = Vector3.Distance(player.transform.position, gameObject.transform.position);

            if (dist < distance && bounce == false)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

            }
           
        }

    }
    

}
