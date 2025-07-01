using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject[] camarasIniciales;      // Objetos como Mapa, Sala, Pasillo1, etc.
    public GameObject[] camarasConEnemigo;     // Objetos alternativos que se activan luego (ej: Pasillo1enemigo, etc.)

    public float tiempoCambio = 5f; // Tiempo hasta que cambia a la versi�n con enemigo

    private GameObject actualActiva = null;
    private Coroutine rutinaCambio = null;

    public void ActivarCamara(int indice)
    {
        if (indice < 0 || indice >= camarasIniciales.Length)
        {
            Debug.LogWarning("Índice fuera de rango: " + indice);
            return; // Evita ejecutar el código si el índice es inválido
        }

        Debug.Log("Cambiando cámara a: " + indice);

        // Apaga la anterior si había una
        if (actualActiva != null)
            actualActiva.SetActive(false);

        // Activa la nueva
        camarasIniciales[indice].SetActive(true);
        actualActiva = camarasIniciales[indice];

        // Detiene la rutina anterior si la hay
        if (rutinaCambio != null)
            StopCoroutine(rutinaCambio);

        // Inicia rutina para cambiar a cámara con enemigo
        rutinaCambio = StartCoroutine(CambiarACamaraConEnemigo(indice));
    }

        IEnumerator CambiarACamaraConEnemigo(int indice)
        {
            yield return new WaitForSeconds(tiempoCambio);

            // Desactiva la actual y activa la versi�n con enemigo si existe
            if (actualActiva != null)
                actualActiva.SetActive(false);

            if (camarasConEnemigo[indice] != null)
            {
                camarasConEnemigo[indice].SetActive(true);
                actualActiva = camarasConEnemigo[indice];
            }
        }
    }
