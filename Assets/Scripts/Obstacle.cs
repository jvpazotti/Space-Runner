using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;
    public GameObject explosionPrefab;

    public AudioClip explosionSound; 

    private AudioSource audioSource; 
    void Start()
    {
        // audioSource = gameObject.AddComponent<AudioSource>(); // Adiciona um componente AudioSource ao obstáculo
        // audioSource.clip = explosionSound;
        // audioSource.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag=="Border"){
            Destroy(this.gameObject);
        }
        else if(collision.tag=="Player"){
            Player playerScript = collision.gameObject.GetComponent<Player>();
        if (playerScript != null){
            playerScript.lives--;
            playerScript.UpdateLifeIcons();
            // Aqui, você também pode adicionar uma animação ou efeito sonoro para indicar dano.
        }

        // float clipLength = audioSource.clip.length;
        // audioSource.Play();

        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Opcional: defina um tempo para destruir o efeito de explosão após ser reproduzido
        Destroy(explosion, 2f);

        // Destrua o obstáculo após a colisão
        Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
