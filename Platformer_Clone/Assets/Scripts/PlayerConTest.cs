using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConTest : MonoBehaviour
{
    private Vector3 startPosition;
    //private float deathY = -20f;
    public float speed = 10f;
    public float lives = 3;
    private Rigidbody rigidBodyRef;
    public float jumpForce = 20f;

    // For Heavy Bullet Pack pick up item
    public bool regularBullets = true;
    public bool heavyBullets = false;
    public bool facingRight;
    public bool facingLeft;
    public bool jumpPack = false;

    public float totalHP = 99f;
    public float healthPack = 15f;
    public float extraHealth = 100f;
    public bool hasExtraHealth = false;

    // Start is called before the first frame update
    void Start()
    {
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
            facingLeft = true;
            facingRight = false;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            facingLeft = false;
            facingRight = true;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }


        // Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.3f, Color.red);
/*
        if (transform.position.y <= deathY)
        {
            lives--;
            transform.position = startPosition;
        }
*/
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HeavyBulletPack")
        {
            // turns off the prefab for regular bullet and turns on the prefab for heavy bullets.
            regularBullets = false;
            heavyBullets = true;
            other.gameObject.SetActive(false);
        }
        
        if (other.gameObject.tag == "JumpPack")
        {
            jumpPack = true;
        }

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

        if (other.gameObject.tag == "ExtraHealth")
        {
            hasExtraHealth = true;
            totalHP = totalHP + 100f;
            other.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Gives ability for to the player to raise Y coordinate to 'jump'
    /// </summary>
    private void Jump()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f))
        {
            rigidBodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

}
