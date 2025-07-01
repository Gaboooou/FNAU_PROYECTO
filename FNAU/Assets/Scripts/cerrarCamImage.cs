using UnityEngine;

public class ExitCamera : MonoBehaviour
{
    public GameObject camImage;

    public void CerrarCamara()
    {
        if (camImage != null)
        {
            camImage.SetActive(false);
        }
    }
}
