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

    private void Update()
    {
        transform.position = player.GetComponent<PlayerConTest>().transform.position;
        gunPos = transform.position;
        
        if (player.GetComponent<PlayerConTest>().facingRight == true)
        {
            gunPos.x += 1;
            transform.position = gunPos;
        }
        if (player.GetComponent<PlayerConTest>().facingLeft == true)
        {
            gunPos.x -= 1;
            transform.position = gunPos;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (canShoot == true)
            {
                if (player.GetComponent<PlayerConTest>().heavyBullets == false)
                {
                    ShootBullet();
                }
                if (player.GetComponent<PlayerConTest>().heavyBullets == true)
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
        bulletDirection.GetComponent<RegularBullet>().faceRight = player.GetComponent<PlayerConTest>().facingRight;
        bulletDirection.GetComponent<RegularBullet>().faceLeft = player.GetComponent<PlayerConTest>().facingLeft;
        bulletDirection.GetComponent<RegularBullet>().originPosRight = player.GetComponent<PlayerConTest>().transform.position;
        bulletDirection.GetComponent<RegularBullet>().originPosLeft = player.GetComponent<PlayerConTest>().transform.position;
    }

    private void ShootHeavyBullet()
    {
        GameObject bulletDirection = Instantiate(heavyBulletPrefab, transform.position, transform.rotation);
        bulletDirection.GetComponent<RegularBullet>().faceRight = player.GetComponent<PlayerConTest>().facingRight;
        bulletDirection.GetComponent<RegularBullet>().faceLeft = player.GetComponent<PlayerConTest>().facingLeft;
        bulletDirection.GetComponent<RegularBullet>().originPosRight = player.GetComponent<PlayerConTest>().transform.position;
        bulletDirection.GetComponent<RegularBullet>().originPosLeft = player.GetComponent<PlayerConTest>().transform.position;
    }
}