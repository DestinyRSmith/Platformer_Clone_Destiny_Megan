using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Megan Mix
/// 11/09/23
/// Regular Enemy mechanics; moves left and right; dies if HP reaches 0
/// </summary>
public class NewBehaviourScript : MonoBehaviour
{
    public float travelDistanceRight = 0;
    public float travelDistanceLeft = 0;
    public float speed;

    private float startingX;
    private bool movingRight = true;
    public float totalEnemyHP = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //when the scene starts store the inital x value of this object
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            //if the object is not farther than the startposition + right travel dist, it can move right
            if (transform.position.x <= startingX + travelDistanceRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                movingRight = false;
            }
        }
        else
        {
            //if the object is not farther than the start position + left travel dist, it can move left
            if (transform.position.x >= startingX + travelDistanceLeft)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            //if the object goes too far left, tell it to move right
            else
            {
                movingRight = true;
            }
        }
        
        if (totalEnemyHP == 0)
        {
            Destroy(this.gameObject);
            GetComponent<PlayerController>().enemyCount++;
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            totalEnemyHP = totalEnemyHP - 1f;
        }
        if (other.gameObject.tag == "HeavyBullet")
        {
            totalEnemyHP = totalEnemyHP - 3f;
        }
    }*/
}
