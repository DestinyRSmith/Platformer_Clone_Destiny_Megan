using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Smith, Destiny
// 11/6/2023
// Manages the text and UI in the game

public class UIManager : MonoBehaviour
{
    public TMP_Text totalLivesText;
    public PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        totalLivesText.text = "Total HP: " + playerController.totalHP;
    }
}
