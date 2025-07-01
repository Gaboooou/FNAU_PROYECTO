using UnityEngine;

public class ActivarCamImageAlClic : MonoBehaviour
{
    public GameObject camImage; // Arrastra el GameObject "CamImage" aquí

    private void OnMouseDown()
    {
        camImage.SetActive(true);
    }
}
