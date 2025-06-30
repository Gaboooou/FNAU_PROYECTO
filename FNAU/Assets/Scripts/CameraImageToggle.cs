using UnityEngine;

public class CameraImageToggle : MonoBehaviour
{
    public GameObject camImage;
    public GameObject Mapa;
    public GameObject Pasillo1;
    public GameObject Pasillo2;
    public GameObject Sala;
    public GameObject Pasillo1enemigo;
    public GameObject Pasillo2enemigo;
    public GameObject SalaSinEnemigo;

    private bool isVisible = false;  
    private int currentPasillo = 0;
    private int pasilloActivo = 0; // Variable para saber en qué pasillo está el enemigo

    void Start()
    {
        camImage.SetActive(false);
        Mapa.SetActive(false);
        Pasillo1.SetActive(false);
        Pasillo2.SetActive(false);
        Sala.SetActive(false); 

        // Inicializar imágenes del enemigo
        Pasillo1enemigo.SetActive(false);
        Pasillo2enemigo.SetActive(false);
        SalaSinEnemigo.SetActive(false); // La imagen de la sala sin enemigo no debe estar activa al inicio

        // El enemigo empieza en el pasillo 1
        Pasillo1enemigo.SetActive(true);  // Activar imagen del pasillo 1 con el enemigo
        pasilloActivo = 1;  // El enemigo está en el pasillo 1
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isVisible = !isVisible;
            camImage.SetActive(isVisible);
            Mapa.SetActive(isVisible);

            if (!isVisible)
            {
                Pasillo1.SetActive(false);
                Pasillo2.SetActive(false);
                Sala.SetActive(false);
                Pasillo1enemigo.SetActive(false);
                Pasillo2enemigo.SetActive(false);
                SalaSinEnemigo.SetActive(false); // Al desactivar cámara, ocultamos todo
                currentPasillo = 0;
            }
        }

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
                if (pasilloActivo == 1)
                {
                    Pasillo1enemigo.SetActive(true);  // Mostrar la imagen del pasillo 1 con el enemigo
                    Pasillo2enemigo.SetActive(false);
                }
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
                if (pasilloActivo == 2)
                {
                    Pasillo2enemigo.SetActive(true);  // Mostrar la imagen del pasillo 2 con el enemigo
                    Pasillo1enemigo.SetActive(false);
                }
            }
        }

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
                SalaSinEnemigo.SetActive(true);  // Aseguramos que se muestre la sala sin el enemigo
                Pasillo1enemigo.SetActive(false);
                Pasillo2enemigo.SetActive(false);  // Desactivar imágenes de pasillo con el enemigo
            }
        }
    }

    public void ActivarPasillo(int pasillo)
    {
        Sala.SetActive(false);
        Pasillo1.SetActive(false);
        Pasillo2.SetActive(false);

        // Activar imágenes correspondientes según el pasillo
        if (pasillo == 1)
        {
            Pasillo1.SetActive(true); 
            Pasillo1enemigo.SetActive(true);  // Imagen del pasillo 1 con el enemigo
            Pasillo2enemigo.SetActive(false); 
            SalaSinEnemigo.SetActive(false); // Aseguramos que la sala sin enemigo se desactive
            pasilloActivo = 1;  // El enemigo está en el pasillo 1
        }
        else if (pasillo == 2)
        {
            Pasillo2.SetActive(true); 
            Pasillo2enemigo.SetActive(true);  // Imagen del pasillo 2 con el enemigo
            Pasillo1enemigo.SetActive(false);
            SalaSinEnemigo.SetActive(false); 
            pasilloActivo = 2;  // El enemigo está en el pasillo 2
        }
    }

    public void RegresarASala()
    {
        Pasillo1.SetActive(false);
        Pasillo2.SetActive(false);
        Sala.SetActive(true);
        // Regresar la imagen de la sala sin el enemigo
        SalaSinEnemigo.SetActive(true);
        Pasillo1enemigo.SetActive(false);
        Pasillo2enemigo.SetActive(false);  // Desactivar imágenes del pasillo con el enemigo
    }
}
