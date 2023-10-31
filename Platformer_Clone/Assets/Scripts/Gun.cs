using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRate = 2f;
    public bool shootRight = false;
    private Vector3 gunPos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootBullet", 0, spawnRate);
    }

    private void Update()
    {
        gunPos = GetComponent<PlayerConTest>().transform.position;
    }

    /// <summary>
    /// Shoots the laser prefab from the laser spawner forever
    /// </summary>
    private void ShootBullet()
    {
        GameObject laserInstance = Instantiate(bulletPrefab, transform.position, transform.rotation);
        laserInstance.GetComponent<RegularBullet>().faceRight = shootRight;
    }
}