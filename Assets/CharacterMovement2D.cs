using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2D : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float acceleration = 5;
    [SerializeField] float deceleration = 5;

    float speed;
    float strafe;

    private void Update()
    {
        var w = Input.GetKey(KeyCode.W);
        var s = Input.GetKey(KeyCode.S);
        var d = Input.GetKey(KeyCode.D);
        var a = Input.GetKey(KeyCode.A);

        var isMoving = w || s || d || a;

        if (w)
        {
            speed += acceleration * Time.deltaTime;
        }

        if (s)
        {
            speed -= acceleration * Time.deltaTime;
        }

        if (!w && !s && speed != 0)
        {
            // decelerate speed to zero 
            speed -= Mathf.Sign(speed) * deceleration * Time.deltaTime;
            if (Mathf.Abs(speed) <= deceleration * Time.deltaTime)
                speed = 0;
        }

        if (d)
        {
            strafe += acceleration * Time.deltaTime;
        }

        if (a)
        {
            strafe -= acceleration * Time.deltaTime;
        }

        if (!d && !a && strafe != 0)
        {
            // decelerate strafe to zero
            strafe -= Mathf.Sign(strafe) * deceleration * Time.deltaTime;
            if (Mathf.Abs(strafe) <= deceleration * Time.deltaTime)
                strafe = 0;
        }

        speed = Mathf.Clamp(speed, -1, 1);
        strafe = Mathf.Clamp(strafe, -1, 1);

        animator.SetFloat("speed", speed);
        animator.SetFloat("strafe", strafe);
        animator.SetBool("isMoving", isMoving);
    }

}
