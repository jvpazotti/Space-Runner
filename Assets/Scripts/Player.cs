using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    public float maxOxygen = 100f;  // Valor máximo de oxigênio/combustível.
    public float currentOxygen;     // Quantidade atual de oxigênio/combustível.
    public float oxygenConsumptionRate = 2f;  // Taxa de consumo de oxigênio/combustível por segundo.

    public UnityEngine.UI.Slider oxygenSlider;

    public int lives = 3;

    public GameObject[] lifeIcons;

    public GameObject gameOverPanel;

    public UnityEngine.UI.Text survivalTimeText; 

    public UnityEngine.UI.Text gameOverReasonText;


    private float survivalTimeAtGameOver;

    private AudioSource gameMusic;

    public SpriteRenderer spriteRenderer; // Faça isso público para que você possa atribuir no editor do Unity.


    


    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        currentOxygen = maxOxygen;
        Time.timeScale = 1f;
        gameMusic = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY= Input.GetAxisRaw("Vertical");
        float direrctionX=Input.GetAxisRaw("Horizontal");
        playerDirection=new Vector2(direrctionX,directionY).normalized;
        currentOxygen -= oxygenConsumptionRate * Time.deltaTime;

        if (lives <= 0)
        {
            // Chame a lógica de Game Over aqui
            // Por exemplo, você pode destruir o jogador e carregar a cena de Game Over
            // Destroy(gameObject);
            // SceneManager.LoadScene("GameOverScene");
            survivalTimeAtGameOver = Time.time - GameTimer.startTime;
            string minutes = ((int)survivalTimeAtGameOver / 60).ToString();
            string seconds = (survivalTimeAtGameOver % 60).ToString("f0");
            survivalTimeText.text = "Survival Time: " + minutes + ":" + seconds.PadLeft(2, '0');
            gameOverReasonText.text = "Your ship was destroyed!";
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            spriteRenderer.enabled = false;
            if (gameMusic)
            {
                gameMusic.Stop();
            }
        }

        if (currentOxygen <= 0f) {
            currentOxygen = 0f;
            // Destroy(gameObject);  
            // SceneManager.LoadScene("GameOverScene");// Destroy the player object
            survivalTimeAtGameOver = Time.time - GameTimer.startTime;
            string minutes = ((int)survivalTimeAtGameOver / 60).ToString();
            string seconds = (survivalTimeAtGameOver % 60).ToString("f0");
            survivalTimeText.text = "Survival Time: " + minutes + ":" + seconds.PadLeft(2, '0');
            gameOverReasonText.text = "You ran out of oxygen!";
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            spriteRenderer.enabled = false;
            if (gameMusic)
            {
                gameMusic.Stop();
            }
        }
        oxygenSlider.value = currentOxygen;

        
    }

    public void ReplenishOxygen(float amount){
    currentOxygen += amount;
        if (currentOxygen > maxOxygen)
        {
            currentOxygen = maxOxygen;
        }
    }

    public void UpdateLifeIcons(){
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (i < lives)
                lifeIcons[i].SetActive(true);
            else
                lifeIcons[i].SetActive(false);
        }
    }


    void FixedUpdate()
    {
        rb.velocity=new Vector2(playerDirection.x*playerSpeed,playerDirection.y*playerSpeed);
    }
}
