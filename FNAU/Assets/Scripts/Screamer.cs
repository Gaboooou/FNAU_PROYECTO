using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreamerTrigger : MonoBehaviour
{
    public GameObject joystick;
    public GameObject botonCerrarPuerta;
    public GameObject screamerImage;
    public AudioSource screamerSound;

    public float screamerDuration = 3f;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            StartCoroutine(ScreamerSequence());
        }
    }

    private System.Collections.IEnumerator ScreamerSequence()
    {
        screamerImage.SetActive(true);
        if (screamerSound != null) screamerSound.Play();

        if (joystick != null) joystick.SetActive(false);
        if (botonCerrarPuerta != null) botonCerrarPuerta.SetActive(false);

        yield return new WaitForSeconds(screamerDuration);

        // 🔁 Carga la escena de Game Over directamente
        SceneManager.LoadScene("Gameover");
    }
}