using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : MonoBehaviour
{
    public float speed;
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
    }
    private void FollowPlayer()
    {
        //if player is to the right, go right
        /*if (player.transform.position <= offset)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        //if player is to the left, go left
        if (player)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }*/
        //transform.position = player.transform.position + offset;
    }
}
