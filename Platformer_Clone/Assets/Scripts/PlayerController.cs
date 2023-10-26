using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody rigidBodyRef;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyRef = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //side to side movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleJump();
        }
    }
    private void HandleJump()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f))
        {
            rigidBodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("Player is not touching the ground so they can't jump");
        }
    }
}
