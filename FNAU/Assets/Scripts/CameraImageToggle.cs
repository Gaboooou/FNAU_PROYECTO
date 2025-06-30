using UnityEngine;

public class CameraImageToggle : MonoBehaviour
{
    public GameObject camImage;  // Imagen general de la cámara
    public GameObject Mapa;      // Mapa general, si lo necesitas
    public GameObject Pasillo1;  // Imagen del pasillo 1
    public GameObject Pasillo2;  // Imagen del pasillo 2
    public GameObject Sala;      // Imagen de la sala

    private bool isVisible = false;  // Al principio no está visible
    private int currentPasillo = 0;

    void Start()
    {
        // Asegurarnos de que al inicio, la cámara y las imágenes no se muestren
        camImage.SetActive(false);
        Mapa.SetActive(false);
        Pasillo1.SetActive(false);
        Pasillo2.SetActive(false);
        Sala.SetActive(false);  // No activar ninguna imagen al principio
    }

    void Update()
    {
        // Alternar visibilidad de la cámara con la tecla F
        if (Input.GetKeyDown(KeyCode.F))
        {
            isVisible = !isVisible;
            camImage.SetActive(isVisible);
            Mapa.SetActive(isVisible);

            // Cuando la cámara se desactiva, desactivamos todas las imágenes
            if (!isVisible)
            {
                Pasillo1.SetActive(false);
                Pasillo2.SetActive(false);
                Sala.SetActive(false);
                currentPasillo = 0;
            }
        }

        // Alternar entre imágenes de los pasillos con las teclas 1 y 2
        if (isVisible && Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentPasillo == 1)
            {
                Pasillo1.SetActive(false);
                currentPasillo = 0;
            }
            else
            {
                Pasillo1.SetActive(true);
                Pasillo2.SetActive(false);
                Sala.SetActive(false); 
                currentPasillo = 1;
            }
        }

        if (isVisible && Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentPasillo == 2)
            {
                Pasillo2.SetActive(false);
                currentPasillo = 0;
            }
            else
            {
                Pasillo2.SetActive(true);
                Pasillo1.SetActive(false);
                Sala.SetActive(false);  
                currentPasillo = 2;
            }
        }

        // Alternar entre la imagen de la sala con la tecla 3
        if (isVisible && Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            if (Sala.activeSelf)
            {
                Sala.SetActive(false);  
            }
            else
            {
                Sala.SetActive(true); 
                Pasillo1.SetActive(false);
                Pasillo2.SetActive(false);
                currentPasillo = 0;
            }
        }
    }

    // Función para activar un pasillo específico
    public void ActivarPasillo(int pasillo)
    {
        // Desactivar todas las imágenes
        Sala.SetActive(false);
        Pasillo1.SetActive(false);
        Pasillo2.SetActive(false);

        // Activar la imagen del pasillo correspondiente
        if (pasillo == 1)
        {
            Pasillo1.SetActive(true);  // Activa la imagen del pasillo 1
        }
        else if (pasillo == 2)
        {
            Pasillo2.SetActive(true);  // Activa la imagen del pasillo 2
        }
    }

    // Función para regresar a la imagen de la sala
    public void RegresarASala()
    {
        // Regresa la imagen de la sala
        Pasillo1.SetActive(false);
        Pasillo2.SetActive(false);
        Sala.SetActive(true);  // Activa la imagen de la sala
    }
}


