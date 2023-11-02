using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 15f;
    private Rigidbody rigidBodyRef;
    public float speed = 10f;
    public float totalHP = 99f;
    public bool canTakeDamage = true;

    //public BlinkMechanic blinkMechanics;

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
            transform.Rotate(Vector3.up * 90);
            transform.position += transform.forward * 5 * Time.deltaTime;
            HandleJump();
        }
        GameOver();
        
    }
    public IEnumerator SetInvincible()
    {
        if (canTakeDamage == false)
        {
            //totalHP = the current total hp, can't take damage
        }
        yield return new WaitForSeconds(5F);
        canTakeDamage = true;
    }
    public IEnumerator Blink()
    {
        for (int index = 0; index < 30; index++)
        {
            if (index % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(5f);
        }
        GetComponent<MeshRenderer>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        //if player gets hit they lose 15HP and blink for 5 seconds
        if (other.gameObject.tag == "Enemy")
        {
            totalHP = totalHP - 15f;
            Debug.Log("Total HP = " + totalHP);
            StartCoroutine(Blink());
            StartCoroutine(SetInvincible());
        }
        //if player gets hit they lose 35HP and blink for 5 seconds
        if (other.gameObject.tag == "BigEnemy")
        {
            //when hard enemy hits, you lose 35HP
            totalHP = totalHP - 35f;
            Debug.Log("Total HP = " + totalHP);
            StartCoroutine(Blink());
            StartCoroutine(SetInvincible());
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
