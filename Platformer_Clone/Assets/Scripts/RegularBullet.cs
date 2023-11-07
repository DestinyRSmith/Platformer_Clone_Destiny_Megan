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


    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine(DespawnDelay());
        // Starts the coroutine when the object is instantiated in the scene
    }

    // Update is called once per frame
    void Update()
    {

        // If the bullet should move right, move it right, else move it left
        if (faceRight == true)
        {
            ShootingRight();
            
        }
        
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