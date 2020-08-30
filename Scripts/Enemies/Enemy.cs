using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	//stats variables------------------------------------------------
	public float maxHP;
	[HideInInspector]
	public float currentHP;

	//jump variables-------------------------------------------------
	public float maxJumpHeight = 4;
	public float minJumpHeight = 1;
	public float timeToJumpApex = .4f;
	public float moveSpeed = 6;
	public float accelerationTimeAirborne;
	public float accelerationTimeGrounded;

	//gravity calculation variables-------------------------------------------------
	float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	[HideInInspector]
	public Controller2D controller;
	Animator anim;


	void Start()
    {
        controller = GetComponent<Controller2D>();
		anim = GetComponent<Animator>();
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
		currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
		CalculateVelocity();
		controller.Move(velocity * Time.deltaTime);

		if (controller.collisions.above || controller.collisions.below)
		{
			if (controller.collisions.slidingDownMaxSlope)
			{
				velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
			}
			else
			{
				velocity.y = 0;
			}
		}

		
	}
	void CalculateVelocity()
	{
		velocity.y += gravity * Time.deltaTime;
	}



	public void TakeDamage(float damage)
	{
		
		currentHP -= damage;
		if (currentHP <= 0)
		{
			anim.SetTrigger("Death");
		}
		else
		{
			anim.SetTrigger("Knockback");
		}
	}
}
