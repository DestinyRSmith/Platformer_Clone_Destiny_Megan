using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destiny Smith
// 11/9/23
// Controls gun mechanics
public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject heavyBulletPrefab;
    public GameObject player;
    //public float spawnRate = 2f;
    public bool shootRight;
    public Vector3 gunPos;
    public bool canShoot = true;
    public Quaternion gunRot;

    private void Update()
    {
        // gun follows player movement
        transform.position = player.GetComponent<PlayerController>().transform.position;
        gunPos = transform.position;
        transform.rotation = gunRot;

        // when player faces right, gun is one unit to the right
        if (player.GetComponent<PlayerController>().facingRight == true)
        {
            gunPos.x += 1f;
            transform.position = gunPos;
            if (gunRot.y != -90)
            {
                transform.Rotate(Vector3.up * -90);
            }
        }
        // when player faces left, gun is one unit to the left and rotates 90 degrees
        if (player.GetComponent<PlayerController>().facingLeft == true)
        {
            gunPos.x -= 1f;
            transform.position = gunPos;
            if (gunRot.y != 90)
            {
                transform.Rotate(Vector3.up * 90);
            }

        }

        // When enter key is pressed, bullets shoot
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (canShoot == true)
            {
                if (player.GetComponent<PlayerController>().heavyBullets == false)
                {
                    ShootBullet();
                }
                if (player.GetComponent<PlayerController>().heavyBullets == true)
                {
                    ShootHeavyBullet();
                }
                // start couroutine
                StartCoroutine(ShootDelay());
            }
        }
    }

    /// <summary>
    /// Delays the gun 2 seconds after each fire
    /// </summary>
    /// <returns></returns>
    IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(2);
        canShoot = true;
    }

    /// <summary>
    /// Shoots the laser prefab from the laser spawner forever
    /// </summary>
    private void ShootBullet()
    {
        GameObject bulletDirection = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bulletDirection.GetComponent<RegularBullet>().player = player.GetComponent<PlayerController>();
        bulletDirection.GetComponent<RegularBullet>().faceRight = player.GetComponent<PlayerController>().facingRight;
        bulletDirection.GetComponent<RegularBullet>().faceLeft = player.GetComponent<PlayerController>().facingLeft;
        bulletDirection.GetComponent<RegularBullet>().originPosRight = player.GetComponent<PlayerController>().transform.position;
        bulletDirection.GetComponent<RegularBullet>().originPosLeft = player.GetComponent<PlayerController>().transform.position;
    }

    private void ShootHeavyBullet()
    {
        GameObject bulletDirection = Instantiate(heavyBulletPrefab, transform.position, transform.rotation);
        bulletDirection.GetComponent<RegularBullet>().player = player.GetComponent<PlayerController>();
        bulletDirection.GetComponent<RegularBullet>().faceRight = player.GetComponent<PlayerController>().facingRight;
        bulletDirection.GetComponent<RegularBullet>().faceLeft = player.GetComponent<PlayerController>().facingLeft;
        bulletDirection.GetComponent<RegularBullet>().originPosRight = player.GetComponent<PlayerController>().transform.position;
        bulletDirection.GetComponent<RegularBullet>().originPosLeft = player.GetComponent<PlayerController>().transform.position;
    }
}