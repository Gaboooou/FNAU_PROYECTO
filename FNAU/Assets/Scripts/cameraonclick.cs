using UnityEngine;

public class ActivarCamImageAlClic1 : MonoBehaviour
{
    public GameObject camImage; // Arrastra el GameObject "CamImage" aqu�

    private void OnMouseDown()
    {
        camImage.SetActive(true);
    }
    public void SetOffCamImage()
        { camImage.SetActive(false); }
}
