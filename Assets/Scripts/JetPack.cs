using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    public Vector3 lookDirection;
    private float looksAngle;

    public float jetPackPlumeL;
    public float jetPackPlumeR;

    private Camera theCam;

    private void Start()
    {
        theCam = Camera.main;
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, looksAngle);
        looksAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg -90f;
    }

    private void Update()
    {
        Vector3 mouse = Input.mousePosition;

        Vector3 worldMouse = theCam.ScreenToWorldPoint(mouse);

        lookDirection = theCam.ScreenToWorldPoint(mouse) - transform.position;


        if (worldMouse.x <= transform.parent.position.x)
        {
          
            transform.localPosition = new Vector3(jetPackPlumeR, transform.localPosition.y, transform.localPosition.z);
        }
        else if (worldMouse.x > transform.parent.position.x)
        {
          
            transform.localPosition = new Vector3(jetPackPlumeL, transform.localPosition.y, transform.localPosition.z);
        }

        /*
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch touch = Input.GetTouch(i);

            //lookDirection = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;

            if (touch.phase == TouchPhase.Began)
            {
                //lookDirection = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;

            }

            else if (touch.phase == TouchPhase.Moved)
            {
                lookDirection = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
                GetComponentInParent<PlayerController>().CoolYourJets();
            }

            else if (touch.phase == TouchPhase.Ended)
            {

                GetComponentInParent<PlayerController>().BurnJets();

            }
            ++i;
        */


    }
}

