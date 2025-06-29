using UnityEngine;

public class CameraImageToggle : MonoBehaviour
{
    public GameObject camImage; 
    public GameObject Mapa;     
    public GameObject Pasillo1;  
    public GameObject Pasillo2;
    public GameObject Sala;

    private bool isVisible = false;
    private int currentPasillo = 0;

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
}