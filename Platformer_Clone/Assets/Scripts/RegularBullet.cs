using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Smith, Destiny
// 10/26/2023
// Controls the bullet movements

public class RegularBullet : MonoBehaviour
{
    public float speed = 15f;
    public bool faceRight;
    public bool faceLeft;

    public Vector3 originPosRight;
    public Vector3 originPosLeft;
    public GameObject bulletPrefab;
    //public float spawnRate = 2f;

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
        //transform.position = originPosRight;
        //transform.position = originPosLeft;

        // If the bullet should move right, move it right, else move it left
        if (faceRight == true)
        {
            ShootingRight();
            
        }

        // Need to add in player controller when the player turn right, going right
        // is now true and going left if false, and vice versa for facing left
        
        if (faceLeft == true)
        {
            ShootingLeft();
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
   

    private void ShootingRight()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void ShootingLeft()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}