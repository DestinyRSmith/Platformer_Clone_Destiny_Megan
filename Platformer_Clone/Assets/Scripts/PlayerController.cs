using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 15f;
    private Rigidbody rigidBodyRef;
    public float speed = 10f;
    public float totalHP = 99f;
    public BlinkMechanic blinkMechanics;

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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            HandleJump();
        }
        GameOver();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //when regular enemy hits, you lose 15HP
            totalHP = totalHP - 15f;
            Debug.Log("Total HP = " + totalHP);
            blinkMechanics.blinkDamage();
        }
        if (other.gameObject.tag == "BigEnemy")
        {
            //when hard enemy hits, you lose 35HP
            totalHP = totalHP - 35f;
            Debug.Log("Total HP = " + totalHP);
        }
        
    }
    private void HandleJump()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 5f))
        {
            rigidBodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("Player is not touching the ground so they can't jump");
        }
    }
    
    public void GameOver()
    {
        if (totalHP == 0)
        {
            //switch scene
        }
    }
}
