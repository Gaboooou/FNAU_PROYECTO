using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoriaFnaf : MonoBehaviour
{
    public float tiempoEspera = 5f;
    public AudioSource audioVictoria;

    void Start()
    {
        if (audioVictoria != null)
        {
            audioVictoria.Play();
        }

        Invoke("CargarNoche2", tiempoEspera);
    }

    void CargarNoche2()
    {
        SceneManager.LoadScene("Noche2");
    }
}
