using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Megan Mix
/// 11/09/23
/// Boss Enemy mechanics
/// </summary>
public class BossEnemy : MonoBehaviour
{
    public float speed;
    private float startingX;
    public float travelDistanceRight = 0;
    public float travelDistanceLeft = 0;
    private bool movingRight = true;
    public static float totalEnemyHP = 100f;
    public bool JumpMode = true;

    public GameObject topPosObject;
    public GameObject bottomPosObject;
    private Vector3 topPos;
    private Vector3 bottomPos;
    public float upwardSpeed;
    public float downwardSpeed;
    public bool movingUp;
    public bool waiting;

    // Start is called before the first frame update
    void Start()
    {
        //when the scene starts store the inital x value of this object
        startingX = transform.position.x;
        topPos = topPosObject.transform.position;
        bottomPos = bottomPosObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(JumpMode == false)
        {
            Movement();
        }
        if(JumpMode == true)
        {
            Jumping();
        }
        Movement();
    }
    // deals damage to Boss's HP
    public static void BossDamage()
    {
        totalEnemyHP = totalEnemyHP - 1f;
        Debug.Log("HP = " + totalEnemyHP);
    }

    /// <summary>
    /// Handles jumping movement for Boss Enemy
    /// </summary>
    public void Jumping()
    {
        if (!waiting)
        {

            if (movingUp)
            {
                //Check to see if the object is too high/reached the top
                if (transform.position.y >= topPos.y)
                {
                    //Too high/reached the top.So switch directions
                    movingUp = false;
                    //start wait time
                    StartCoroutine(Wait(3));
                }
                else
                {
                    //Not at the top, so move upwards
                    transform.position += Vector3.up * upwardSpeed * Time.deltaTime;
                }
            }
            else
            {
                //check to see the object has reached the bottom
                if (transform.position.y <= bottomPos.y)
                {
                    movingUp = true;
                    //start wait time
                    StartCoroutine(Wait(1));
                }
                else
                {
                    transform.position += Vector3.down * downwardSpeed * Time.deltaTime;
                }
            }

        }
    }
    /// <summary>
    /// Pauses the Bosses movement for a certain amount of time
    /// </summary>
    /// <param name="secondsToWait"></param>
    /// <returns></returns>
    IEnumerator Wait(float secondsToWait)
    {
        waiting = true;
        yield return new WaitForSeconds(secondsToWait);
        waiting = false;
    }
    /// <summary>
    /// Handles side to side movement for Boss Enemy
    /// </summary>
    public void Movement()
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
    }
}
