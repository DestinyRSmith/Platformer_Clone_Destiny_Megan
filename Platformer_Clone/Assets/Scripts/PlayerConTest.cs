using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConTest : MonoBehaviour
{
    private Vector3 startPosition;
    private float deathY = -5;
    private float speed = 10f;
    public float lives = 3;
    private Rigidbody rigidBodyRef;
    public float jumpForce = 5f;

    // For Heavy Bullet Pack pick up item
    public bool regularBullets = true;
    public bool heavyBullets = false;
    public bool facingRight;
    public bool facingLeft;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigidBodyRef = GetComponent<Rigidbody>();
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

        if (transform.position.y <= deathY)
        {
            lives--;
            transform.position = startPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HeavyBulletPack")
        {
            // turns off the prefab for regular bullet and turns on the prefab for heavy bullets.
            regularBullets = false;
            heavyBullets = true;
            other.gameObject.SetActive(false);
        }

    }

    private void Jump()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f))
        {
            rigidBodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

}
