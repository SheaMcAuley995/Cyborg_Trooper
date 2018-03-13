using UnityEngine;
using System.Collections;

public class DirectionalMove : MonoBehaviour {

    private Rigidbody2D rb;

	// Animation script
	private CharacterAnimation anim;

	// Speed variables
	private float speed = 10f;
	private float speedHalved = 7.5f;
	private float speedOrigin = 10f;

	void Start()
	{
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<CharacterAnimation>(); // Get the animation script
	}

	// FixedUpdate is used for physics based movement
	void FixedUpdate () 
	{
		float horizontal = Input.GetAxis("Horizontal"); // set a float to control horizontal input
		float vertical = Input.GetAxis("Vertical"); // set a float to control vertical input
		PlayerMove(horizontal,vertical); // Call the move player function sending horizontal and vertical movements
	}
	
	private void PlayerMove(float h, float v)
	{
		if (h != 0f || v != 0f) // If horizontal or vertical are pressed then continue
		{
			if(h != 0f && v != 0f) // If horizontal AND vertical are pressed then continue
			{
				speed = speedHalved; // Modify the speed to adjust for moving on an angle
			}
			else // If only horizontal OR vertical are pressed individually then continue
			{
				speed = speedOrigin; // Keep speed to it's original value
			}

			Vector2 targetDirection = new Vector2(h, v); // Set a direction using Vector3 based on horizontal and vertical input
			rb.MovePosition(rb.position + targetDirection * speed * Time.deltaTime); // Move the players position based on current location while adding the new targetDirection times speed
			RotatePlayer(targetDirection); // Call the rotate player function sending the targetDirection variable
			anim._animRun = true; // Enable the run animation
		}
		else 	// If horizontal or vertical are not pressed then continue
		{
			anim._animRun = false; // Disable the run animation
		}
	}
	
	private void RotatePlayer(Vector2 dir)
	{
		//rb.MoveRotation(Quaternion.LookRotation(dir)); // Rotate the player to look at the new targetDirection
	}
	
}
