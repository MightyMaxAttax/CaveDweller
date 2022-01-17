using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    GameObject player;

    public int health;

    public Image[] myHearts;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        health = PlayerController.playerHealth;
    }

    private void Update()
    {

        health = PlayerController.playerHealth;

        for (int i = 0; i < myHearts.Length; i++)
        {
            if (i < health)
            {
                myHearts[i].enabled = true;

            }
            else
            {
                myHearts[i].enabled = false;

            }
        }

    }
}
