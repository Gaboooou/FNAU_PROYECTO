using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RelojFnaf : MonoBehaviour
{
    public TMP_Text textoHora; // TextMeshPro UI

    public float segundosPorHora = 90f;
    private float tiempoTranscurrido = 0f;
    private int horaActual = 0;
    private string[] horas = { "12 AM", "1 AM", "2 AM", "3 AM", "4 AM", "5 AM", "6 AM" };
    private bool activo = true;

    void Start()
    {
        textoHora.text = horas[horaActual];
    }

    void Update()
    {
        if (!activo) return;

        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= segundosPorHora)
        {
            tiempoTranscurrido = 0f;
            horaActual++;

            if (horaActual >= horas.Length)
            {
                horaActual = horas.Length - 1;
                activo = false;

                SceneManager.LoadScene("Victoria"); 
            }

            textoHora.text = horas[horaActual];
        }
    }
}