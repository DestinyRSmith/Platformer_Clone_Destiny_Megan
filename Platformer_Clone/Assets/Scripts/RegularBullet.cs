using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Smith, Destiny
// 10/26/2023
// Controls the bullet movements

public class RegularBullet : MonoBehaviour
{
    public float speed = 5f;
    public bool faceRight;
    public bool faceLeft;

    private Vector3 originPos;
    public GameObject bulletPrefab;
    public float spawnRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnDelay());
        // Starts the coroutine when the object is instantiated in the scene
        // StartCoroutine(DespawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
        faceRight = GetComponent<PlayerConTest>().facingRight;
        faceLeft = GetComponent<PlayerConTest>().facingLeft;
        originPos = GetComponent<PlayerConTest>().transform.position;
        // If the bullet should move right, move it right, else move it left
        if (faceRight == true && Input.GetKeyDown(KeyCode.P))
        {
            originPos += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            originPos += Vector3.left * speed * Time.deltaTime;
        }

        // Need to add in player controller when the player turn right, going right
        // is now true and going left if false, and vice versa for facing left
        if (faceLeft == true && Input.GetKeyDown(KeyCode.P))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        
    }
    /// <summary>
    /// Yields before destroying the game object tagged "Bullet"
    /// </summary>
    /// <returns></returns>
    IEnumerator DespawnDelay()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}