using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        transform.position = player.GetComponent<PlayerController>().transform.position;
        gunPos = transform.position;
        transform.rotation = gunRot;

        if (player.GetComponent<PlayerController>().facingRight == true)
        {
            gunPos.x += 1f;
            transform.position = gunPos;
            if (gunRot.y != -90)
            {
                transform.Rotate(Vector3.up * -90);
            }
        }

        if (player.GetComponent<PlayerController>().facingLeft == true)
        {
            gunPos.x -= 1f;
            transform.position = gunPos;
            if (gunRot.y != 90)
            {
                transform.Rotate(Vector3.up * 90);
            }

        }

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
        bulletDirection.GetComponent<RegularBullet>().faceRight = player.GetComponent<PlayerController>().facingRight;
        bulletDirection.GetComponent<RegularBullet>().faceLeft = player.GetComponent<PlayerController>().facingLeft;
        bulletDirection.GetComponent<RegularBullet>().originPosRight = player.GetComponent<PlayerController>().transform.position;
        bulletDirection.GetComponent<RegularBullet>().originPosLeft = player.GetComponent<PlayerController>().transform.position;
    }

    private void ShootHeavyBullet()
    {
        GameObject bulletDirection = Instantiate(heavyBulletPrefab, transform.position, transform.rotation);
        bulletDirection.GetComponent<RegularBullet>().faceRight = player.GetComponent<PlayerController>().facingRight;
        bulletDirection.GetComponent<RegularBullet>().faceLeft = player.GetComponent<PlayerController>().facingLeft;
        bulletDirection.GetComponent<RegularBullet>().originPosRight = player.GetComponent<PlayerController>().transform.position;
        bulletDirection.GetComponent<RegularBullet>().originPosLeft = player.GetComponent<PlayerController>().transform.position;
    }
}