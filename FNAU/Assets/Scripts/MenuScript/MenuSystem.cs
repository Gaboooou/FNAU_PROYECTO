using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SoundManager.instance.ActivarEfecto("click-tap-computer-mouse-352734");
    }

    public void Salir() 
    {
        Debug.Log("Saliendo del juego...");
    }
}
