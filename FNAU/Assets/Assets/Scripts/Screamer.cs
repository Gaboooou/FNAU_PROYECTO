using UnityEngine;
using UnityEngine.UI;

public class ScreamerTrigger : MonoBehaviour
{
    public GameObject screamerImage;
    public AudioSource screamerSound;

     // Referencia al script GameOver

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            screamerImage.SetActive(true);  // Mostrar imagen
            screamerSound.Play();           // Reproducir sonido       // ❄️ Congelar el juego        
        }
    }
}
