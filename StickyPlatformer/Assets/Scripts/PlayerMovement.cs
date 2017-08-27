using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	[SerializeField]
	Transform _transform;

	[SerializeField]
	Rigidbody2D rb;

	[SerializeField]
	float moveSpeed, jumpPower, rotateSpeed, maxMoveSpeed;

	[SerializeField]
	CompositeCollider2D totalCollider;

	public SimpleAudioEvent jumpSound;

	public bool grounded;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		Rotate ();
		Jump ();
	}

	void Rotate()
	{
		if(Input.GetButton ("RotateLeft"))
		{
			_transform.Rotate (Vector3.forward * rotateSpeed);
		}
		if(Input.GetButton ("RotateRight"))
		{
			_transform.Rotate (Vector3.back * rotateSpeed);
		}
	}

	void Jump()
	{
		if(Input.GetButtonUp ("Jump") && grounded)
		{
			rb.AddForce (Vector2.up * jumpPower);
			jumpSound.PlayOneShot (SoundManager.sfxPlayer);
			grounded = false;
		}
	}

//	bool IsGrounded()
//	{
//		Vector2 distToGround = _transform.position;
//		distToGround.y -= totalCollider.bounds.extents.y;
//		grounded = Physics2D.Raycast (distToGround, -Vector2.up, 0.1f);
//		Debug.DrawRay (distToGround, -Vector2.up,Color.red,10f);
//		return grounded;
//	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider != totalCollider)
		{
			grounded = true;
		}
	}

	void Move()
	{
		float horizontalMove = Input.GetAxis ("Horizontal");
		if(horizontalMove > 0.1f)
		{
			if (rb.velocity.sqrMagnitude <= maxMoveSpeed)
			{
				rb.AddForce (Vector2.right * moveSpeed);

			}
			//_transform.Translate (Vector2.right *moveSpeed);
		} else if (horizontalMove < -0.1f)
		{
			if (rb.velocity.sqrMagnitude <= maxMoveSpeed)
			{
				rb.AddForce (-(Vector2.right *moveSpeed));
			}
			//_transform.Translate (-(Vector2.right *moveSpeed));
		}
	}
}
