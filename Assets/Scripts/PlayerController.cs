using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Transform jetPack;
    private JetPack jetPackScript;
    public float moveSpeed;
  
    public bool IsDisabled;
      
    bool IsStopped;

    public Rigidbody2D rb;

    [SerializeField]
    public static int playerHealth;

    
    [SerializeField]
    private float speed;

    [SerializeField]
    private float distance;

    public GameObject jetPlume;
    public GameObject jetPlume2;

    public Animator playerAnim;

    //private BoxCollider2D boxCollider;
    //private Vector3 moveDelta;
    //private RaycastHit2D hit;


    //private uint tensionID;
    void Start()
    {
        IsStopped = false;
        //boxCollider = gameObject.GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerHealth = 3;

    }

    public void CoolYourJets()
    {
        rb.AddForce(jetPack.up * (moveSpeed/2));
        playerAnim.SetBool("IsCoolingJets", true);
     
    }

    public void BurnJets()
    {
        playerAnim.SetBool("IsCoolingJets", false);
        playerAnim.SetTrigger("BurnJets");
        rb.AddForce(jetPack.up * moveSpeed);
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == ("GravityGem"))
        {
            
            IsStopped = true;
        }

       
    }

    IEnumerator WaitForShot()
    {
        yield return new WaitForSeconds(1);
        IsDisabled = false;
        
    }
    public void ShootRespawn()
    {
        StartCoroutine(WaitForShot()); ;

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Obstacles")
        {
            playerHealth -= 1;
        }

    }

   
    private void FixedUpdate()
    {
       /*
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        moveDelta = new Vector3(x, y, 0);

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if(hit.collider == null)
        {
            rb.AddForce(new Vector2(0, moveDelta.y * Time.deltaTime) * (moveSpeed*16));
           
            //transform.Translate(0, moveDelta.y * Time.deltaTime, 0);

        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            rb.AddForce(new Vector2(moveDelta.x * Time.deltaTime, 0) * (moveSpeed * 16));

            //transform.Translate(moveDelta.x * Time.deltaTime, 0 , 0);

        }
       */

    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;

    }

    // Update is called once per frame
    void Update()
    {

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("GAME OVER");
        }

       if (jetPack.position.x > transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = enabled;
        }

        else if (jetPack.position.x <= transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = !enabled;
        }
     

        if (IsStopped == true)
        {
            rb.isKinematic = true;
            rb.velocity = new Vector2(0,0);
        }



        if (Input.GetMouseButtonDown(0) && IsDisabled == false)
        {
          
            IsStopped = false;

        }
        if (Input.GetMouseButtonDown(0) && IsDisabled == false && IsStopped == false)
        {
            rb.isKinematic = false;
            CoolYourJets();
            IsDisabled = false;
        }


        if (Input.GetMouseButtonUp(0) && IsDisabled == false && IsStopped == false)
        {
            rb.isKinematic = false;
            BurnJets();
            IsDisabled = false;
        }

        //TOUCH
       int i = 0;
        while (i < Input.touchCount)
        {
            Touch touch = Input.GetTouch(i);

            //jetPackScript.lookDirection = Camera.main.ScreenToWorldPoint(touch.position) - jetPack.transform.position;

            if (touch.phase == TouchPhase.Began && IsDisabled == false && IsStopped == false)
            {

            }

            else if (touch.phase == TouchPhase.Moved && IsDisabled == false && IsStopped == false)
            {
         
            }
           
            else if (touch.phase == TouchPhase.Ended && IsDisabled == false && IsStopped == false)
            {
                 
               

            }
            ++i;


        }

        foreach (GameObject gravitygem in GameObject.FindGameObjectsWithTag("GravityGem"))
            
        {
            float dist = Vector3.Distance(gravitygem.transform.position, gameObject.transform.position);

            if (dist <= distance)
            {
                rb.velocity = Vector2.zero;
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, gravitygem.transform.position, step);

            }
        }

    }
}
   





















