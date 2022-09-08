using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCcontrols : MonoBehaviour
{

    private bool canJump;

    private bool jump;

    public CharacterController character;

    public float speed = 5f;

    public float gravity = -9.81f;

    public float jumpSpeed = 50f;

    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public float speedmod = 1f;

    public LayerMask groundMask;

    Vector3 velocity;
    bool IsGrounded;


    void Start () {
        Invoke("SendSpeedModifier", 0.5f);
    }
    // Start is called before the first frame update
    void Update()
    {
		if (character.isGrounded)
		{
		}
    IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    if(IsGrounded && velocity.y < 0)
    {
        velocity.y = -2f;
    }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

if(move.magnitude>1)
                 move/=move.magnitude;
        character.Move(move * speed * speedmod * Time.deltaTime);
        



        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);
    }
    	public void SetSpeedModifier(float speedMod)
	{
speedmod = speedMod;
	}
}
