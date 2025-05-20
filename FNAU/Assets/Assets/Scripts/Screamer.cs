using UnityEngine;
using UnityEngine.UI;

public class ScreamerTrigger : MonoBehaviour
{
    public GameObject screamerImage;
    public AudioSource screamerSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            screamerImage.SetActive(true);  // Mostrar imagen
            screamerSound.Play();           // Reproducir sonido
            Time.timeScale = 0f;            // ❄️ Congelar el juego
        }
    }
}
