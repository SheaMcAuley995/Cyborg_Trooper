using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//[RequireComponent(typeof(LineRenderer))]
//[RequireComponent(typeof(Rigidbody2D))]

public class JumpBox : MonoBehaviour {

    //PLAYER MOVEMENT 

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
        playerRb = GetComponent<Rigidbody2D>();
        playerSize = GetComponent<BoxCollider2D>().size;
        boxSize = new Vector2(playerSize.x -1, groundedSkin);
    }

    private void Start()
    {



    }

    void Update()
    {
        hookStart = transform.position;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumpRequest = true;
        }
        if (Input.GetMouseButtonDown(0) && !isHooking)
        {
            // Find mouse position
            Vector3 mouseInput = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector2 mouseClick = cam.ScreenToWorldPoint(mouseInput);


            //Find direction (ray)
            Vector3 rayDirection = mouseClick - (Vector2)this.transform.position;
            Vector3 rayNormalised = rayDirection.normalized;
            //Vector3 r = Quaternion.Euler(0, 90, 0) * rayNormalised;
            GameObject baby = Instantiate(hook/*, transform.position + (rayDirection.normalized * 1.2f), Quaternion.Euler(r)*/);
            baby.transform.position = transform.position + (rayDirection.normalized * 1.2f);
            hookRb = baby.GetComponent<Rigidbody2D>();
            baby.GetComponent<GrappleHook>().daddy = this;
            hookObj = baby;
            isHooking = true;
            hookStart = baby.transform.position;
            hookEnd =  baby.transform.position + (Vector3)(rayDirection.normalized * hookLength);

            StartCoroutine(moveHook());
            //hookRb.AddForce(rayDirection.normalized * 25, ForceMode2D.Impulse);
            
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
        //if(isHooking)
        //{
        //   // LerpBaby(hookStart, hookEnd);
        //}
        float h = Input.GetAxis("Horizontal");
        Move(h);
    }

    private void Move(float speed)
    {
        playerRb.velocity = new Vector2(speed * characterSpeed, playerRb.velocity.y);
    }

    //private void LerpBaby(Vector3 start, Vector3 end)
    //{
    //    if(hookObj != null)
    //    {
    //        hookObj.transform.position = Vector3.Lerp(start, end, hookSpeed * Time.deltaTime);
            
    //    }
    //}

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