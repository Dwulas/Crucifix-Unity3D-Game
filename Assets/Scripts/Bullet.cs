using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Player;
    public ParticleSystem deathParticles;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy();
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    public void Destroy()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Player.SetActive(false);
        // Destroy(gameObject);
    }
}
