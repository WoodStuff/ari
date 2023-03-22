using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	/// <summary>
	/// The Rigidbody2D attached to the player.
	/// </summary>
	public Rigidbody2D rigid;
	public float speed = 1f;
	public float jumpHeight = 1.5f;
	public float raycastOffset = 0.51f;
	public float rayDistance = 0.05f;

	void Update()
	{
		Vector2 move = new(Input.GetAxisRaw("Horizontal"), 0);
		rigid.AddRelativeForce(500 * speed * Time.deltaTime * move);

		if (Input.GetAxisRaw("Jump") > 0 && GroundCheck() && rigid.velocity.y <= 0) rigid.velocity = new Vector2(rigid.velocity.x, jumpHeight * 5);
		Debug.DrawRay(rigid.position - new Vector2(0.5f, raycastOffset), Vector2.down * new Vector2(0, rayDistance), Color.green);
		Debug.DrawRay(rigid.position - new Vector2(-0.5f, raycastOffset), Vector2.down * new Vector2(0, rayDistance), Color.blue);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// do stuff when colliding with another object thats meant to do stuff when you collide with it
	}

	private bool GroundCheck()
	{
		bool left = false;
		bool right = false;

		// left
		RaycastHit2D hit1 = Physics2D.Raycast(rigid.position - new Vector2(0.5f, raycastOffset), Vector2.down);
		if (!(hit1.collider == null || hit1.distance > rayDistance) && hit1.collider.gameObject.CompareTag("Island")) left = true;

		// right
		RaycastHit2D hit2 = Physics2D.Raycast(rigid.position - new Vector2(-0.5f, raycastOffset), Vector2.down);
		if (!(hit2.collider == null || hit2.distance > rayDistance) && hit2.collider.gameObject.CompareTag("Island")) right = true;
		return left || right;
	}
}