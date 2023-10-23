using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenCylinder : MonoBehaviour
{

    public AudioClip collectionSound; 
    private AudioSource audioSource;

    public float oxygenValue = 20f; // Quantidade de oxigênio fornecida ao jogador ao coletar este cilindro.

    void Start()
    {
    // audioSource = gameObject.AddComponent<AudioSource>();
    // audioSource.clip = collectionSound;
    // audioSource.volume = 0.5f;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.ReplenishOxygen(oxygenValue);
            // audioSource.Play();
            Destroy(gameObject); // Destruir o cilindro após a coleta.
        }
    }
}
