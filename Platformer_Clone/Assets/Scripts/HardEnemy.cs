using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : MonoBehaviour
{
    //public float travelDistanceRight = 0;
    //public float travelDistanceLeft = 0;
    public float speed;

    private float startingX;
    private bool movingRight = true;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        //when the scene starts store the inital x value of this object
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController == movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            movingRight = false;
        }
    }
}
