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
    //public static GameObject hardEnemyPrefab;
    public float speed;
    public static float hardEnemyHP = 10f;
    public GameObject player;
    private float startingX;
    private bool movingRight;
    public float travelDistanceRight = 0;
    public float travelDistanceLeft = 0;

    //bool BulletTouch = other.gameObject.GetComponent<RegularBullet>().BulletHit();

    // Start is called before the first frame update
    void Start()
    {
        //when the scene starts store the inital x value of this object
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (transform.position.x <= startingX + travelDistanceRight)
        {
            if (player.transform.position.x > transform.position.x)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
    }
    public static void DamageDealt()
    {
        hardEnemyHP = hardEnemyHP - 1f;
        Debug.Log("HP = " + hardEnemyHP);
    }
}
