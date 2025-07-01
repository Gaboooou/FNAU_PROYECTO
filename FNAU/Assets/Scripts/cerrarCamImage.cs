using UnityEngine;

public class ExitCamera : MonoBehaviour
{
    public GameObject camImage;    // La referencia a la imagen de la cámara que deseas cerrar
    public GameObject[] camaras;   // Las cámaras que se deben desactivar al cerrar la cámara

    // Método para cerrar la cámara
    public void CerrarCamara()
    {
        if (camImage != null)
        {
            // Desactiva la imagen de la cámara
            camImage.SetActive(false);

            Debug.Log("La cámara ha sido cerrada.");
        }
        else
        {
            Debug.LogWarning("No se ha asignado la imagen de la cámara.");
        }

        // Desactiva todas las cámaras
        if (camaras != null)
        {
            foreach (GameObject camara in camaras)
            {
                camara.SetActive(false);  // Desactiva cada cámara
            }
        }
    }
}