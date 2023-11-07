using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject player;
    //public float spawnRate = 2f;
    public bool shootRight;
    public Vector3 gunPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        transform.position = player.GetComponent<PlayerConTest>().transform.position;
        gunPos = transform.position;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ShootBullet();
        }
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
}