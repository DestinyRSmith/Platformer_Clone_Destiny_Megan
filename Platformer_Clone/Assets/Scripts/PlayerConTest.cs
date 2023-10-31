using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConTest : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        // Gets the rigidbody component off of this object and stores a reference to it
        rigidBodyRef = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // side to side movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        // Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.3f, Color.red);

        if (transform.position.y <= deathY)
        {
            Respawn();
        }
    }

}
