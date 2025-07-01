using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using TMPro;

public class VictoriaFnaf : MonoBehaviour
{
    public float tiempoTexto = 5f;              // Tiempo que se muestra el texto
    public VideoPlayer videoPlayer;            // El componente VideoPlayer
    public GameObject videoUI;                 // El RawImage que muestra el video (RenderTexture)
    public GameObject textoVictoriaUI;         // El texto de "¡Llegaste a las 6 AM!"
    public AudioSource audioVictoria;          // Audio inicial

    void Start()
    {
        Debug.Log("Iniciando victoria");

        if (audioVictoria != null)
        {
            audioVictoria.Play();
            Debug.Log("Reproduciendo audio victoria");
        }

        if (textoVictoriaUI != null)
            textoVictoriaUI.SetActive(true);

        if (videoUI != null)
            videoUI.SetActive(false);

        Invoke(nameof(MostrarVideo), tiempoTexto);
    }

    void MostrarVideo()
    {
        // Ocultar el texto
        if (textoVictoriaUI != null)
            textoVictoriaUI.SetActive(false);

        // Mostrar el RawImage del video
        if (videoUI != null)
            videoUI.SetActive(true);

        if (videoPlayer != null)
        {
            videoPlayer.Play();
            videoPlayer.loopPointReached += VideoTermino;
        }
    }

    void VideoTermino(VideoPlayer vp)
    {
        SceneManager.LoadScene("InGame");
    }
}
    