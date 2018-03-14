using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//[RequireComponent(typeof(LineRenderer))]
//[RequireComponent(typeof(Rigidbody2D))]

public class JumpBox : MonoBehaviour {
    public static JumpBox instance;
    //PLAYER MOVEMENT 

    RopeScript ropeScript;

    float rbX;
    float rbY;



    GameObject curHook;
    public bool ropeActive;


    public float bulletSpeed;
    public GameObject bullet;
    
    public Transform playerGraphics;


        //Jump Speed
    [Range(1, 20)]
    public float jumpVelocity;
    public float groundedSkin = 0.05f;

        //Move Speed
    [Range(1, 10)]
    public float characterSpeed;
    [Range(1, 10)]
    public float hookLength;
    [Range(0, 0.4f)]
    public float travelTime = 0.125f;

    //Collision Detection
    Rigidbody2D playerRb;
    public LayerMask mask;

    bool jumpRequest;
    bool grounded;

    Vector2 playerSize;
    Vector2 boxSize;

    //END PLAYER MOVEMENT
    //
    //
    //ROPE MECANICS
    public Camera cam;
    public GameObject hook;
    public float hookSpeed;
    //
    //END ROPE MECHANICS
    //




    private void Awake()
    {

        JumpBox.instance = this;

        playerRb = GetComponent<Rigidbody2D>();


        playerSize = GetComponent<BoxCollider2D>().size;
        boxSize = new Vector2(playerSize.x -1, groundedSkin);
        playerGraphics = transform.Find("Graphics");
        if (playerGraphics == null)
        {
            Debug.LogError("NO GRAPHIICSSSSSS Which is like fine for now because really I just want to get the arm moving first");
        }
    }

    void Update()
    {
       // hookStart = transform.position;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumpRequest = true;
        }

        if(Input.GetButton("Jump") && ropeActive)
        {
            //transform.position = 
        }


        if (Input.GetMouseButtonDown(1))
        {

            if (!ropeActive)
            {
                Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);

                curHook.GetComponent<RopeScript>().destiny = destiny;
                ropeActive = true;
            }
            else
            {
                Vector2 dir = curHook.transform.position - transform.position;
                playerRb.AddForce(dir.normalized * hookSpeed, ForceMode2D.Impulse);
                Destroy(curHook);
                    ropeActive = false;
                //StartCoroutine(PlayerZoom());

            }
        }
    }


        
    private void FixedUpdate()
    {
        rbX = playerRb.velocity.x;
        rbY = playerRb.velocity.y;

        
        if (jumpRequest)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);

            grounded = false;
            jumpRequest = false;
        }
        else
        {
            Vector2 boxCenter = (Vector2)transform.position + Vector2.down * (playerSize.y + boxSize.y) * 0.05f;
            grounded = (Physics2D.OverlapBox(boxCenter,boxSize,0f,mask) != null);
        }

        float h = Input.GetAxis("Horizontal");
        if (!ropeActive)
        {

            Move(h * 20);
           
           // rbY = Mathf.Clamp(rbY, -10, 10);
            playerRb.velocity = new Vector2(rbX, playerRb.velocity.y);
        }
        else if (ropeActive)
        {
                Move(h * 200);
        }


        if (grounded)
        {
            rbX = Mathf.Clamp(rbX, -10, 10);
        }

    }

    private void Move(float speed)
    {
        Vector2 movement = new Vector2(speed,0);
        playerRb.AddForce(movement, ForceMode2D.Force);
        //
        // new Vector2(speed * characterSpeed, playerRb.velocity.y);
    }

    IEnumerator PlayerZoom()
    {
        Vector2 destiny = curHook.transform.position;
        Vector2 startPos = transform.position;
        Vector2 dir = curHook.transform.position - transform.position;
        float t = 0;
        Destroy(curHook);
        while (t < 1)
        {
            t += Time.deltaTime;
            Debug.DrawLine(transform.position,transform.position + ((Vector3)dir.normalized * 10));
            //.position = Vector2.Lerp(startPos, destiny, t);
            Debug.Log(dir);
            playerRb.AddForce(dir.normalized * t* hookSpeed);
            yield return null;
        }

        ropeActive = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

}