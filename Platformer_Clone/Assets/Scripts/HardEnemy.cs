using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Megan Mix
/// 11/09/23
/// Hard Enemy mechanics; follows player around level; dies if HP reaches 0
/// </summary>
public class HardEnemy : MonoBehaviour
{
    public float speed;
    public float hardEnemyHP = 10f;
    public GameObject player;
    private float startingX;
    private bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        //when the scene starts store the inital x value of this object
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
       if (player.transform.position.x > transform.position.x)
       {
            transform.position += Vector3.right * speed * Time.deltaTime;
       }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (hardEnemyHP == 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hardEnemyHP = hardEnemyHP - 1f;
        }
        if (other.gameObject.tag == "HeavyBulletPack")
        {
            hardEnemyHP = hardEnemyHP - 3f;
        }
    }
}
