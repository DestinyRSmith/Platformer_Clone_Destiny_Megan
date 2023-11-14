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
    public GameObject hardEnemyPrefab;

    public static int deathCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Starts the coroutine when the object is instantiated in the scene
        StartCoroutine(DespawnDelay());
    }

    // Update is called once per frame
    void Update()
    {

        // If the bullet should move right, move it right, else move it left
        if (faceRight == true)
        {
            ShootingRight();
            BulletHit();

        }
        
        if (faceLeft == true)
        {
            ShootingLeft();
            BulletHit();
        }
        Debug.Log("death count: " + deathCount);
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
    public void BulletHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 1))
        {
            if (hit.collider.tag == "BigEnemy")
            {
                HardEnemy.DamageDealt();
                if (HardEnemy.hardEnemyHP <= 0)
                {
                    deathCount++;
                    Destroy(hit.collider.gameObject);
                }
                Destroy(bulletPrefab.gameObject);
                
            }
            if (hit.collider.tag == "Enemy")
            {
                deathCount++;
                Destroy(hit.collider.gameObject);
                Destroy(bulletPrefab.gameObject);
            }
            if (hit.collider.tag == "BossEnemy")
            {
                Debug.Log("Hit Boss");
                BossEnemy.BossDamage();
                if (BossEnemy.totalEnemyHP == 0)
                {
                    Destroy(hit.collider.gameObject);
                }
                Destroy(bulletPrefab.gameObject);
            }
        }
    }
}