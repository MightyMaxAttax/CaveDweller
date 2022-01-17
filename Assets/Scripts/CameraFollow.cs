using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    public float boundX = 0.15f;
    public float boundY = 0.05f;

    /*void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
        }
    }
    */

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        if (player != null)
        {

            float deltaX = player.position.x - transform.position.x;
            if (deltaX > boundX || deltaX < -boundX)
            {
                if (transform.position.x < player.position.x)
                {
                    delta.x = deltaX - boundX;
                }
                else
                {
                    delta.x = deltaX + boundX;
                }
            }

            float deltaY = player.position.y - transform.position.y;
            if (deltaY > boundY || deltaY < -boundY)
            {
                if (transform.position.y < player.position.y)
                {
                    delta.y = deltaY - boundY;
                }
                else
                {
                    delta.y = deltaY + boundY;
                }
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);

    }

}
