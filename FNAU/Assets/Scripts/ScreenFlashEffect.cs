using UnityEngine;
using UnityEngine.UI;

public class ScreenFlashEffect : MonoBehaviour
{
    public Image flashImage;
    public float flashSpeed = 2f;
    public bool isFlashing = false;

    private float alpha = 0f;
    private bool increasing = true;

    void Update()
    {
    if (!isFlashing || flashImage == null) return;

    alpha += (increasing ? 1 : -1) * flashSpeed * Time.deltaTime;

    if (alpha >= 1f) // Opacidad total (negro solido)
    {
    alpha = 1f;
    increasing = false;
    }
    else if (alpha <= 0f)
    {
        alpha = 0f;
        increasing = true;
    }

    var c = flashImage.color;
    c.a = alpha;
    flashImage.color = c;
    }
    public void StartFlashing()
    {
        isFlashing = true;
    }

    public void StopFlashing()
    {
        isFlashing = false;
        Color c = flashImage.color;
        c.a = 0f;
        flashImage.color = c;
    }
}
