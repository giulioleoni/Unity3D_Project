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

    //public float points;
    //private float keyValue = 15;
    //private float moneyValue = 50;
    //private float pointsBasedOnTime = 1500;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
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

        // GRAVITY
        gravityForce.y += gravityValue * Time.deltaTime;
        controller.Move(gravityForce * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Collectible"))
        //{
        //    Destroy(other.gameObject);
        //    collectibles++;
        //    collectiblesNumberText.text = collectibles.ToString();
        //}

        //if (other.CompareTag("Key"))
        //{
        //    Destroy(other.gameObject);
        //    keys++;
        //    keyText.text = keys.ToString();
        //}

        //if (other.CompareTag("Door") && keys > 0)
        //{
        //    other.GetComponent<DoorBehavior>().activated = true;
        //    other.GetComponent<DoorBehavior>().Open();
        //    keys--;
        //    keyText.text = keys.ToString();
        //}

        //if (other.CompareTag("Grail"))
        //{
        //    CalculatePoints();
        //    Transporter.Instance.LoadNextScene(2);
        //}
    }

    private void CalculatePoints()
    {
        //if (keys > 0)
        //{
        //    points += keys * keyValue;
        //}

        //if (moneys > 0)
        //{
        //    points += moneys * moneyValue;
        //}

        //float timePoints = Mathf.Clamp(pointsBasedOnTime - Timer.Instance.timeValue, 0, 1000);
        
        //points += timePoints;
        
        //Transporter.Instance.playerPoints = points;
    }
}
