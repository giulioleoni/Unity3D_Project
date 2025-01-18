using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.01f);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Wall"))
            {
                Destroy(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
