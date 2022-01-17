using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //GameObject player;

    private void Start()
    {
        
        //player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            gameObject.SetActive(false);
            Invoke("RespawnGem", 3f);

        }
    }

    void RespawnGem()
    {
        gameObject.SetActive(true);
    }

 

}
