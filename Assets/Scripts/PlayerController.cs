using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Rigidbody myBody;
    public AudioSource sfxAudioPlayer;

    public AudioClip jumpUpSound;
    public AudioClip jumpDownSound;
    public AudioClip gameOverSound;

    public float rayCastDistance = 1f;
    public float maxSpeed;
	public float moveAcceleration;
	public float jumpAcceleration;
    public float gameOverHeight = -5f;
	private bool isGrounded = false;
    private bool isGameOver = false;

	void FixedUpdate ()
	{
        GroundChecker ();
		ConstantMove ();
	}

	void Update()
	{
        //check for game over
        if (transform.position.y < gameOverHeight && isGameOver == false)
        {
            isGameOver = true;
            sfxAudioPlayer.PlayOneShot(gameOverSound);
        }

        //jump
		if (isGrounded && 
            ( Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0) ) )
		{
			Jump ();
		}

        //visualize raycast in GroundChecker()
        Debug.DrawLine(transform.position,
            transform.position + Vector3.down * rayCastDistance);
    }

    //play jump down sound
	void OnCollisionEnter(Collision collisionInfo)
	{
        sfxAudioPlayer.PlayOneShot(jumpDownSound);
	}

	/// <summary>
	/// this function moves the ball on z axis
	/// </summary>
	void ConstantMove()
	{
		Vector3 newVelocity = myBody.velocity;

		//don't move with higher speed than maxSpeed
		if (newVelocity.z >= maxSpeed)
		{
			newVelocity.z = maxSpeed;
		}

		//accelerate to max speed
		else
		{
			newVelocity.z = newVelocity.z + moveAcceleration;
		}

		myBody.velocity = newVelocity;
	}

    /// <summary>
    /// Checks if the player is on the ground
    /// </summary>
    void GroundChecker()
    {
        Ray ray = new Ray();

        ray.origin = transform.position;
        ray.direction = Vector3.down;

        //launch ray to check if player is grounded
        isGrounded = Physics.Raycast(ray, rayCastDistance);
    }

    /// <summary>
    /// makes the player jump
    /// </summary>
    void Jump()
	{
		Vector3 jumpVelocity = myBody.velocity;
		jumpVelocity.y = jumpVelocity.y + jumpAcceleration;
		myBody.velocity = jumpVelocity;

        sfxAudioPlayer.PlayOneShot(jumpUpSound);
	}
}
