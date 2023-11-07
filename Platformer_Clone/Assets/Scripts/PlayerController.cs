using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
   // variables for movement
    private Vector3 startPosition;
    public float jumpForce = 15f;
    private Rigidbody rigidBodyRef;
    public float speed = 10f;
    public bool facingRight;
    public bool facingLeft;

    // variables for health
    public float totalHP = 99f;
    public bool canTakeDamage = true;
    public bool firstHit = true;
    public float healthPack = 15f;
    public float extraHealth = 100f;
    public bool hasExtraHealth = false;

    // variables for bullets
    public bool regularBullets = true;
    public bool heavyBullets = false;

    //public BlinkMechanic blinkMechanics;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyRef = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //side to side movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            facingLeft = true;
            facingRight = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            facingLeft = false;
            facingRight = true;
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
    public IEnumerator Blink()
    {
        firstHit = false;
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
            yield return new WaitForSeconds(0.1667f);
        }
        GetComponent<MeshRenderer>().enabled = true;
        firstHit = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        //if player gets hit they lose 15HP and blink for 5 seconds
        if (other.gameObject.tag == "Enemy")
        {
            if (firstHit == true)
            {
                totalHP = totalHP - 15f;
                StartCoroutine(Blink());
            }
            if (canTakeDamage == true)
            {
                totalHP = totalHP - 15f;
            }
            Debug.Log("Total HP = " + totalHP);
            
        }
        //if player gets hit they lose 35HP and blink for 5 seconds
        if (other.gameObject.tag == "BigEnemy")
        {
            //when hard enemy hits, you lose 35HP
            totalHP = totalHP - 35f;
            Debug.Log("Total HP = " + totalHP);
            StartCoroutine(Blink());
        }

        if (other.gameObject.tag == "HeavyBulletPack")
        {
            // turns off the prefab for regular bullet and turns on the prefab for heavy bullets.
            regularBullets = false;
            heavyBullets = true;
            other.gameObject.SetActive(false);
        }

        // heals the player 15 HP
        if (other.gameObject.tag == "HealthPack")
        {
            if (totalHP <= 84f || hasExtraHealth == true && totalHP <= 184f)
            {
                totalHP = totalHP + healthPack;
                other.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Your health is too full.");
            }
        }

        // adds 100 HP to max health
        if (other.gameObject.tag == "ExtraHealth")
        {
            hasExtraHealth = true;
            totalHP = totalHP + 100f;
            other.gameObject.SetActive(false);
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
