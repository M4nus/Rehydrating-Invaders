using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class SpaceshipMovement : MonoBehaviour
{
    // It's a direction of movement based on input (-1 (left), 1 (right))
    private Vector2 moveDirection;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // Here write your movement code :D
    }

    public void OnMove(InputValue input)
    {
        // I'm getting an input (WSAD, Arrows or Gamepad) and assigning it's value to Vector2 that has 0 in Y axis as we just want to move left and right
        Vector2 inputDirection = input.Get<Vector2>();
        moveDirection = new Vector2(inputDirection.x, 0f);
    }
}
