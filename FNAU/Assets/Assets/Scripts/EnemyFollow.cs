using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public AudioSource tensionMusic;  // Música tensión

    private bool isChasing = true;
    private bool tensionStarted = false; // Para saber si ya empezó la música

    private void Update()
    {
        if (isChasing && tensionStarted && tensionMusic != null && !tensionMusic.isPlaying)
        {
            tensionMusic.Play();
        }

        if (!isChasing && tensionMusic != null && tensionMusic.isPlaying)
        {
            tensionMusic.Stop();
        }

        if (!isChasing || player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = false;

            if (tensionMusic != null && tensionMusic.isPlaying)
            {
                tensionMusic.Stop();
            }

            Debug.Log("Jugador atrapado!");
        }

        if (other.CompareTag("Door"))
        {
            if (tensionMusic != null && !tensionMusic.isPlaying)
            {
                tensionMusic.Play();
                tensionStarted = true;
                Debug.Log("Música de tensión activada al tocar la puerta.");
            }
        }
    }
}
