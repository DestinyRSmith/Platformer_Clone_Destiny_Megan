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
    private bool movingRight = true;
    public float travelDistanceRight = 7;
    public float travelDistanceLeft = 7;

    /*
    public float lvl1MaxX = 34f;
    public float lvl1MinX = -7f;
    public float lvl2MaxX = 84f;
    public float lvl2MinX = 44f;
    public float lvl3MinX = 96f;
    public float lvl3MaxX = 136f;
    public float lvl4MinX = 149f;
    public float lvl4MaxX = 213f;
    */


    // Start is called before the first frame update
    void Start()
    {
        //when the scene starts store the inital x value of this object
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight == true)
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
    }

    /// <summary>
    /// Handles damage dealt to enemy
    /// </summary>
    public static void DamageDealt()
    {
        hardEnemyHP = hardEnemyHP - 1f;
        Debug.Log("HP = " + hardEnemyHP);
    }
    public static void DealingDamage()
    {
        hardEnemyHP = hardEnemyHP - 3f;
        Debug.Log("HP = " + hardEnemyHP);
    }
}
