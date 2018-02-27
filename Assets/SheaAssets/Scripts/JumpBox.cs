using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public class JumpBox : MonoBehaviour {

    //PLAYER MOVEMENT 

        //Jump Speed
    [Range(1, 10)]
    public float jumpVelocity;
    public float groundedSkin = 0.05f;

        //Move Speed
    [Range(1, 10)]
    public float characterSpeed;


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


    //
    //END ROPE MECHANICS
    //




    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSize = GetComponent<BoxCollider2D>().size;
        boxSize = new Vector2(playerSize.x, groundedSkin);
    }

    private void Start()
    {



    }

    void Update()
    {

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumpRequest = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            // Find mouse position
            Vector3 mouseInput = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector2 mouseClick = cam.ScreenToWorldPoint(mouseInput);


            //Find direction (ray)
            Vector3 rayDirection = mouseClick - (Vector2)this.transform.position;
            Vector3 rayNormalised = rayDirection.normalized;
            Vector3 r = Quaternion.Euler(0, 90, 0) * rayNormalised;
            GameObject baby = Instantiate(hook, transform.position + (rayDirection.normalized * 1.2f), Quaternion.Euler(r));
            hookRb = baby.GetComponent<Rigidbody2D>();



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

        float h = Input.GetAxis("Horizontal");
        Move(h);
    }

    private void Move(float speed)
    {
        playerRb.velocity = new Vector2(speed * characterSpeed, playerRb.velocity.y);
    }

    private void LerpBaby(Transform start, Transform end)
    {

    }


}