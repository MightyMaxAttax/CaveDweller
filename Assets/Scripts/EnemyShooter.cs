using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    private float distance = 2f;

    [SerializeField]
    private float speed = 2f;

    public GameObject projectile;
    public GameObject shooter;

    private Vector3 lookDirection;
    private float looksAngle;
    bool lookingAtPlayer = false;
    float nextShotTime;
    public float shotTime = 2f;

    void Start()
    {
        
      player = GameObject.FindGameObjectWithTag("Player");
        

    }

    private void FixedUpdate()
    {
        if (lookingAtPlayer == true && player != null)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, looksAngle);
            looksAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            lookDirection = player.transform.position - transform.position;

        }
    }

    
    private void Update()
    {

        if (player != null)
        {
            float dist = Vector3.Distance(player.transform.position, gameObject.transform.position);

            if (dist < distance)
            {
                //Aim at Player
                lookingAtPlayer = true;
                
                //float step = speed * Time.deltaTime;

                if (Time.time > nextShotTime)
                {
                    GameObject enemyBullet = (GameObject)Instantiate(projectile, shooter.transform.position, shooter.transform.rotation); //√
                    //Rigidbody2D rb = enemyBullet.GetComponent<Rigidbody2D>();
                    //rb.AddForce(-enemyBullet.transform.up * speed);
                    nextShotTime = Time.time + shotTime;
                }

            }
            else
            {
                lookingAtPlayer = false;
            }

        }

                
    }
}
