using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlinkMechanic : MonoBehaviour
{
    public GameObject Canvas1;
    public float totalHP = 99f;
    void Start()
    {
        Canvas1.gameObject.SetActive(false);
    }
    

        public void blinkDamage()
        {
            if (totalHP == 84)
            {
                Canvas1.gameObject.SetActive(true);
            }
        }
    
    
}
