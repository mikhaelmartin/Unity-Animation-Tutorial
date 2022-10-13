using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] Animator animator;

    float speed;
    bool isMoving;


    private void Update()
    {
        // if button press, speed up. else speed down
        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            speed += 0.5f * Time.deltaTime;
        }
        else
        {
            isMoving = false;
            speed -= Time.deltaTime;
        }

        // speed value is between 0 - 1 for simplicity
        speed = Mathf.Clamp01(speed);

        animator.SetBool("isMoving", isMoving);
        animator.SetFloat("speed", speed);        
    }

}
