using UnityEngine;

public class ActivarCamImageAlClic : MonoBehaviour
{
    public GameObject camImage; // Arrastra el GameObject "CamImage" aqu�

    private void OnMouseDown()
    {
        camImage.SetActive(true);
    }
}
