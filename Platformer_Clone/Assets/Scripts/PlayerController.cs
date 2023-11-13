using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
/// <summary>
/// Megan Mix & Destiny Smith
/// 11/09/23
/// Main Player Controller Script
/// </summary>
public class PlayerController : MonoBehaviour
{
   // variables for movement
    private Vector3 startPosition;
    public float jumpForce = 5f;
    public float jumpCount = 0f;
    public bool jumpPack = false;
    private Rigidbody rigidBodyRef;
    public float speed = 10f;
    public bool facingRight;
    public bool facingLeft;
    public float deathY = -10f;

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
    public GameObject bullet;
    public GameObject heavyBullet;

    // for switching scenes
    public float enemyCount = 0f;

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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
           // transform.Rotate(Vector3.up * 90);
           // transform.position += transform.forward * 5 * Time.deltaTime;
            HandleJump();
        }

        //For switching to heavy bullets
        if (heavyBullets == true)
        {
            bullet.gameObject.SetActive(false);
            heavyBullet.gameObject.SetActive(true);
        }

        if (transform.position.y <= deathY)
        {
            totalHP -= 15f;
            transform.position = startPosition;
        }

        if (enemyCount == 4f)
        {
            SceneManager.LoadScene(2);
        }
        else if (enemyCount == 8f && heavyBullets == true)
        {
            SceneManager.LoadScene(3);
        }
        else if (enemyCount == 12f && jumpPack == true)
        {
            SceneManager.LoadScene(4);
        }
        else if (enemyCount == 18f)
        {
            SceneManager.LoadScene(6);
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
            if (firstHit == true)
            {
                totalHP = totalHP - 35f;
                StartCoroutine(Blink());
            }
            if (canTakeDamage == true)
            {
                totalHP = totalHP - 35f;
            }
            Debug.Log("Total HP = " + totalHP);
        }
        if (other.gameObject.tag == "BossEnemy")
        {
            if (firstHit == true)
            {
                totalHP = totalHP - 20f;
                StartCoroutine(Blink());
            }
            if (canTakeDamage == true)
            {
                totalHP = totalHP - 20f;
            }
            Debug.Log("Total HP = " + totalHP);
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

        if (other.gameObject.tag == "JumpPack")
        {
            jumpPack = true;
            other.gameObject.SetActive(false);
        }

    }
    /// <summary>
    /// Gives ability for to the player to raise Y coordinate to 'jump', if jump pack collected, can double jump
    /// </summary>
    private void HandleJump()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f))
        {
            rigidBodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount = 1;
        }
        else
        {
            if (jumpCount == 1f && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && jumpPack == true)
            {
                rigidBodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpCount++;
            }
            jumpCount = 0f;
        }
    }

    public void GameOver()
    {
        if (totalHP <= 0)
        {
            SceneManager.LoadScene(5);
        }
    }
}
