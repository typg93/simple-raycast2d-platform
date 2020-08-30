using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMoveSMB : StateMachineBehaviour
{
    Controller2D controller;
    Enemy enemy;
    float transTimer;
    public float transMinTime;
    public float transMaxTime;
    Vector2 test = new Vector2(-1, 0);

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.GetComponent<Controller2D>();
        enemy = animator.GetComponent<Enemy>();
        transTimer = Random.Range(transMinTime, transMaxTime);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (transTimer <= 0)
        {
            animator.SetTrigger("Idle");
        }
        else
        {
            transTimer -= Time.deltaTime;
        }

        enemy.controller.Move(new Vector2(enemy.moveSpeed, 0) *Time.deltaTime);
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
