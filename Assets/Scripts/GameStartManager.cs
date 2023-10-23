using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("GameScene");  // Carrega a cena principal do jogo
    }
}