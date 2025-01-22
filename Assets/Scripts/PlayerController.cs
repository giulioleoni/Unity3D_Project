using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine;




public class PlayerController : MonoBehaviour
{
    private Transform cam;
    private bool isCharacterGrounded;
    private float gravityValue = -9.81f;
    private Vector3 gravityForce;

    private PlayerInput playerInput;
    private InputAction MoveAction;

    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;
    [SerializeField] private CharacterController controller;


    

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        MoveAction = playerInput.actions["Move"];
    }



    void Start()
    {
        cam = Camera.main.transform;
    }

    void Update()
    {
        isCharacterGrounded = controller.isGrounded;

        if (isCharacterGrounded && gravityForce.y < 1.0f)
        {
            gravityForce.y = 0;
        }

        Vector3 movement = new Vector3(MoveAction.ReadValue<Vector2>().x, 0, MoveAction.ReadValue<Vector2>().y);
        Debug.Log(movement);

        // ROTATION
        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Quaternion angle = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, angle, rotSpeed * Time.deltaTime);
            Vector3 rotatedMovement = angle * Vector3.forward;
            controller.Move(rotatedMovement * speed * Time.deltaTime);
        }

        ApplyGravity();
    }
     
    private void ApplyGravity()
    {
        gravityForce.y += gravityValue * Time.deltaTime;
        controller.Move(gravityForce * Time.deltaTime);
    }

    //private void MovePlayer()
    //{
    //    Vector2 moveDir = InputsController.GetInputValue<Vector2>("MoveDir"); // gets normalized input move directions from the input system.
    //    Vector3 playerVelocity = Vector3.zero;

    //    currentMoveDirAccelerated = Vector2.Lerp(currentMoveDirAccelerated, moveDir, accelerationSpeed * Time.deltaTime);

    //    playerVelocity += cam.transform.right * currentMoveDirAccelerated.x * playerMoveSpeed;
    //    playerVelocity += cam.transform.forward * currentMoveDirAccelerated.y * playerMoveSpeed;
    //    playerVelocity *= 0.5f;
    //    playerVelocity.y = 0;

    //    if (playerVelocity != Vector3.zero)
    //    {
    //        Vector3 playerForward = playerVelocity;

    //        if (IsAiming)
    //        {
    //            playerForward = Vector3.forward;

    //            if (Mathf.Abs(moveDir.y) > 0.5f)
    //            {
    //                playerForward += cam.transform.right * moveDir.x * playerMoveSpeed;
    //            }

    //            playerForward += cam.transform.forward * Mathf.Abs(moveDir.y) * playerMoveSpeed;
    //            playerForward *= 0.5f;
    //            playerForward.y = 0;
    //        }

    //        transform.forward = Vector3.Lerp(transform.forward, playerForward, playerTurnRate * Time.deltaTime);
    //    }

    //    float idleMoveBlender = currentMoveDirAccelerated.magnitude; // Calculate the magnitude of the movement vector.
    //    animatorController.SetFloat("Speed_f", idleMoveBlender); // Set the "Speed_f" parameter in the animator based on the current speed.
    //    animatorController.SetBool("Static_b", !InputsController.OnInputTrigger("MoveDir")); // Set the "Static_b" parameter in the animator based on the movement state.

    //    playerVelocity.y = gravityVelocity;

    //    charController.Move(playerVelocity * Time.deltaTime);
    //}
}
