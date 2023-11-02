using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //FollowPlayer();
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
