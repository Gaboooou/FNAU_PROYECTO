using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class estatica : MonoBehaviour
{
    public Material glitchMaterial;   // Material con el shader glitch
    public Image targetImage;         // Componente Image (UI)
    
    private Material originalMaterial;
    private bool glitchOn = false;

    void Start()
    {
        if (targetImage != null)
        {
            originalMaterial = targetImage.material;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            glitchOn = !glitchOn;

            if (glitchOn)
                targetImage.material = glitchMaterial;
            else
                targetImage.material = originalMaterial;
        }
    }
}
