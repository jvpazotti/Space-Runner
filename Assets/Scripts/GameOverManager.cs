using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    
    public void RestartGame()
    { // Reseta o estado de game over
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");  // Carrega a cena principal do jogo
    }

}
