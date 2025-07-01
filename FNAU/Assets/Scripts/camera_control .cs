using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class CameraController : MonoBehaviour
{
    public GameObject[] camarasIniciales;      // Objetos como Mapa, Sala, Pasillo1, etc.
    public GameObject[] camarasConEnemigo;

    public GameObject[] camarasActuales;   // Objetos alternativos que se activan luego (ej: Pasillo1enemigo, etc.)
// Tiempo hasta que cambia a la versión con enemigo

    private GameObject actualActiva = null;


    public float TiempoEspera = 5f;


    void Start()
    {
        StartCoroutine(SecuenciaEnemigo());
    }

    // Activar cámara inicial
    public void ActivarCamara(int indice)
    {
        if (indice < 0 || indice >= camarasActuales.Length)
        {
            Debug.LogWarning("Índice fuera de rango: " + indice);
            return; // Evita ejecutar el código si el índice es inválido
        }

        Debug.Log("Cambiando cámara a: " + indice);

        // Apaga la anterior si había una
        if (actualActiva != null)
            actualActiva.SetActive(false);

        // Activa la nueva
        camarasActuales[indice].SetActive(true);
        actualActiva = camarasActuales[indice];

    }

    IEnumerator SecuenciaEnemigo()
    {

        while (true)
        {
            yield return new WaitForSeconds(TiempoEspera);

            int direccion = Random.Range(1, 3);
            Debug.Log("¡El enemigo ha ido hacia " + (direccion == 1 ? "la izquierda" : "la derecha") + "!");

            SoundManager.instance.ActivarEfecto("Estatica");
            for (int i = 0; i < 3; i++) // Asumiendo que 1, 2 y 3 pueden cambiar
            {
                if (camarasActuales[i] != null)
                    camarasActuales[i].SetActive(false);
            }

            if (direccion == 1)
            {
                camarasActuales[1] = camarasConEnemigo[1];
                camarasActuales[0] = camarasConEnemigo[0];
                Debug.Log("camara obstruida 1");
            }
            else if (direccion == 2)
            {
                camarasActuales[2] = camarasConEnemigo[2];
                camarasActuales[0] = camarasConEnemigo[0];
                Debug.Log("camara obstruida 2");
            }

            yield return new WaitForSeconds(TiempoEspera);

            
            
            SoundManager.instance.ActivarEfecto("Estatica");
            
            Debug.Log("¡El enemigo ha atacado!");

        
            for (int i = 0; i < 3; i++) // Asumiendo que 1, 2 y 3 pueden cambiar
            {
                if (camarasActuales[i] != null)
                    camarasActuales[i].SetActive(false);
            }

            camarasActuales[0] = camarasIniciales[0];
            camarasActuales[1] = camarasIniciales[1];
            camarasActuales[2] = camarasIniciales[2];
            Debug.Log("camaras restablecidas");
            
        }
    }

    // Cambiar a la cámara con enemigo

}