using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Megan Mix 
/// 11/09/23
/// Camera Player tracking
/// </summary>
public class CameraTracking : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
