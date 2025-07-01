using UnityEngine;
using UnityEngine.UI;

public class ActivarImagen : MonoBehaviour
{
    public GameObject imagen;  // El objeto con el componente Image

    public void Activar()
    {
        if (imagen != null)
        {
            imagen.SetActive(true);
        }
    }
}
