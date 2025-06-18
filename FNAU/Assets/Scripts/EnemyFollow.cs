using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public AudioSource tensionMusic;  // Musica tension
    public ScreenFlashEffect screenFlashEffect;

    private bool isChasing = true;
    private bool tensionStarted = false;

    private void Update()
    {
        // Si esta persiguiendo y no ha empezado tension
        if (isChasing)
        {
            if (!tensionStarted)
            {
                tensionStarted = true;

                if (tensionMusic != null && !tensionMusic.isPlaying)
                    tensionMusic.Play();

                if (screenFlashEffect != null)
                    screenFlashEffect.StartFlashing();
            }

            if (player != null)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
            }
        }
        else
        {
            // Cuando no esta persiguiendo, detener musica y parpadeo
            if (tensionStarted)
            {
                tensionStarted = false;

                if (tensionMusic != null && tensionMusic.isPlaying)
                    tensionMusic.Stop();

                if (screenFlashEffect != null)
                    screenFlashEffect.StopFlashing();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = false;

            Debug.Log("Jugador atrapado!");
        }
    }
}