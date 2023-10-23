using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DifficultyController : MonoBehaviour
{
    public CameraMovement cameraScript;
    public SpawnObstacles spawnObstaclesScript;

    public GameObject phaseTextObject;  // O GameObject do texto UI
    public float phaseTextDisplayTime = 2f; // Tempo que o texto será exibido

    private float elapsedTime = 0f;
    private int currentPhase = 0;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        // Ajustar dificuldade com base no tempo
        if (elapsedTime >= 30f && elapsedTime < 60f && currentPhase != 1) // 1a fase após 1 minuto
        {
            cameraScript.SetSpeed(1.25f); // Acelerar
            spawnObstaclesScript.SetSpawnRate(1.25f); // Mais obstáculos
            currentPhase = 1;
            UpdatePhase("Phase 1: Easy");
        }
        else if (elapsedTime >= 60f && elapsedTime < 120f && currentPhase != 2) // 2a fase após 2 minutos
        {
            cameraScript.SetSpeed(1.25f); // Desacelerar
            spawnObstaclesScript.SetSpawnRate(1.25f); // Ainda mais obstáculos
            currentPhase = 2;
            UpdatePhase("Phase 2: Medium");
        }
        else if (elapsedTime >= 120f && elapsedTime < 150f && currentPhase != 3) // 3a fase após 3 minutos
        {
            cameraScript.SetSpeed(1.1f); // Acelerar novamente
            spawnObstaclesScript.SetSpawnRate(1.1f); // Ainda mais e mais obstáculos
            currentPhase = 3;
            UpdatePhase("Phase 3: Hard");
        }
         else if (elapsedTime >= 150f && elapsedTime < 180f && currentPhase != 4) // 3a fase após 3 minutos
        {
            cameraScript.SetSpeed(1.1f); // Acelerar novamente
            spawnObstaclesScript.SetSpawnRate(1.1f); // Ainda mais e mais obstáculos
            currentPhase = 4;
            UpdatePhase("Phase 4: Very Hard");
        }
        else if (elapsedTime >= 180f && currentPhase != 5) // 3a fase após 3 minutos
        {
            cameraScript.SetSpeed(1.1f); // Acelerar novamente
            spawnObstaclesScript.SetSpawnRate(1.1f); // Ainda mais e mais obstáculos
            currentPhase = 5;
            UpdatePhase("Phase 5: Insane");
        }
    }

    private void UpdatePhase(string phaseText)
    {
        phaseTextObject.GetComponent<Text>().text = phaseText; // Se estiver usando TMPro, mude "Text" para "TextMeshProUGUI"
        phaseTextObject.SetActive(true);
        StartCoroutine(HideTextAfterDelay());
    }

    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(phaseTextDisplayTime);
        phaseTextObject.SetActive(false);
    }

}
