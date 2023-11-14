using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Smith, Destiny
// 11/6/2023
// Controls the game over scene when the playeer dies. Retry button will retart the game, quit
// button will quit the game.

public class GameOver : MonoBehaviour
{
    public PlayerController player;
    public void RetryGame()
    {
        SceneManager.LoadScene(1);
        player.heavyBullets = false;
        player.jumpPack = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
