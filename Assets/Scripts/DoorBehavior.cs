using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    private float rotSpeed = 3;
    public bool activated = false;
    public Transform player;
    public Transform door;
    public Quaternion targetRot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!activated)
        {
            return;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);

        if (transform.rotation == targetRot)
        {
            Destroy(transform.GetComponent<DoorBehavior>());
        }
    }

    public void Open()
    {
        player = GameObject.FindWithTag("Player").transform;
        float dot = Vector3.Dot(door.forward, (player.position - door.position).normalized);
        float targetAngle = transform.rotation.eulerAngles.y;
        if (dot > 0)
        {
            targetAngle += -90;
            targetRot = Quaternion.Euler(0, targetAngle, 0);
        }
        else
        {
            targetAngle += 90;
            targetRot = Quaternion.Euler(0, targetAngle, 0);
        }

        GetComponent<BoxCollider>().enabled = false;
    }

}
