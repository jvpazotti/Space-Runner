using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameTimer : MonoBehaviour
{
    public Text timerText; // Referência ao componente Text para exibir o tempo.
    public static float startTime;


    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        float t = Time.time - startTime;
        
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f0"); // "f2" limita a exibição a duas casas decimais.

        timerText.text = "Time " + minutes + ":" + seconds.PadLeft(2, '0');

    }
}
