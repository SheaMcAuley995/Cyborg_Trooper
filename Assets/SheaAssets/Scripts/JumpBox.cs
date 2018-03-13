using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//[RequireComponent(typeof(LineRenderer))]
//[RequireComponent(typeof(Rigidbody2D))]

public class JumpBox : MonoBehaviour {
    public static JumpBox instance;
    //PLAYER MOVEMENT 

    RopeScript ropeScript;
    
    
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
    Rigidbody2D hookRb;

    GameObject hookObj;
    Vector3 hookStart;
    Vector3 hookEnd;
    bool isHooking;
    public float hookSpeed;
    //
    //END ROPE MECHANICS
    //




    private void Awake()
    {
<<<<<<< HEAD
        JumpBox.instance = this;
        //ropeScript = GetComponent<RopeScript>();
=======
<<<<<<< HEAD
=======
        JumpBox.instance = this;
        //ropeScript = GetComponent<RopeScript>();
>>>>>>> shea
>>>>>>> 9dbfe7b4dcc7f4f14534908e0a9fdcfb58fe4ba4
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
        hookStart = transform.position;
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
               Destroy(curHook);
                ropeActive = false;
            }
        }
    }


        
    private void FixedUpdate()
    {

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
        Move(h);
    }

    private void Move(float speed)
    {
        playerRb.velocity = new Vector2(speed * characterSpeed, playerRb.velocity.y);
    }


    IEnumerator moveHook()
    {
       Rigidbody2D c = hookObj.GetComponent<Rigidbody2D>();

        float t = 0;
        while(t < 1)//whatever parameter you want
        {

            //Vector3 B_start = hookStart;
            //Vector3 B_end = hookEnd;
            t += Time.deltaTime / travelTime;
            Vector2 lerpPos = Vector2.Lerp(hookStart, hookEnd, t);
            c.MovePosition(lerpPos);
           // Debug.Log(t);
            yield return null;
        }

        Destroy(hookObj);
        isHooking = false;
        //Cleanup after you leave the while loop


    }
}