using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void RetryGame()
    {
        // Reinicia la escena anterior (ej. la de juego)
        SceneManager.LoadScene("InGame");  // Cambia este nombre
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");  // Asegúrate de tener esta escena en Build Settings
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Solo para el editor
#endif
    }
}
