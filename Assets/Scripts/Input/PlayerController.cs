using UnityEngine.InputSystem;
using UnityEngine;




public class PlayerController : MonoBehaviour
{
    private Transform cam;
    private float gravityValue = -9.81f;
    private Vector3 movement;

    private PlayerInput playerInput;
    private InputAction moveAction;

    [SerializeField] private float speed;
    [SerializeField] private float playerRotationSpeed;
    [SerializeField] private CharacterController controller;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
    }

    void Start()
    {
        cam = Camera.main.transform;
    }

    void Update()
    {
        if (controller.isGrounded && movement.y < 0)
        {
            movement.y = 0;
        }

        MovementDirection();
        
        if (movement.magnitude > 0.1f)
        {
            Rotate();
        }

        movement.y += gravityValue;

        controller.Move(movement * speed * Time.deltaTime);
    }

    private void MovementDirection()
    {
        Vector2 newMovement = moveAction.ReadValue<Vector2>();
        movement.x = newMovement.x;
        movement.z = newMovement.y;
    }

    private void Rotate()
    {
        float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        Quaternion angle = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, angle, playerRotationSpeed * Time.deltaTime);
        movement = angle * Vector3.forward;
    }

}
