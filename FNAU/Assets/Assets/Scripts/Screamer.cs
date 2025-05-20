using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreamerTrigger : MonoBehaviour
{
    public GameObject screamerImage;
    public AudioSource screamerSound;

    public GameObject gameOverImage;
    public GameObject retryButton;
    public AudioSource gameOverSound;     // 🎵 NUEVO: sonido de Game Over

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

        yield return new WaitForSeconds(screamerDuration);

        screamerImage.SetActive(false);
        gameOverImage.SetActive(true);
        retryButton.SetActive(true);

        if (gameOverSound != null) gameOverSound.Play(); // 🎵 Reproduce sonido Game Over

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
