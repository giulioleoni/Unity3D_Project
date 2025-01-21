using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class Player : MonoBehaviour
{
    public Transform cam;
    public float speed;
    public float rotSpeed;
    public CharacterController controller;

    private bool isCharacterGrounded;
    private float gravityValue = -9.81f;
    private Vector3 gravityForce;

    private int collectibles;
    [SerializeField]private TMP_Text collectiblesNumberText;


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

        // INPUT 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

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
}
