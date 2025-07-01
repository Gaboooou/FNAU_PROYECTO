using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float velocidad = 5f;
    public Animator animator;

    private Vector3 escalaOriginal;

    void Start()
    {
        escalaOriginal = transform.localScale;
        SoundManager.instance.ReproducirMusica(SoundManager.instance.MusicaPrincipal);
    }

    void Update()
    {
        // Entrada en ambos ejes
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(inputX, inputY, 0f).normalized;
        Vector3 movimiento = input * velocidad * Time.deltaTime;

        // Aplicar movimiento
        transform.position += movimiento;

        // Animaci�n (velocidad general)
        animator.SetFloat("movement", input.magnitude);

        // Voltear sprite horizontalmente si hay movimiento en X
        if (inputX < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(escalaOriginal.x), escalaOriginal.y, escalaOriginal.z); // mira a la izquierda
        }
        else if (inputX > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(escalaOriginal.x), escalaOriginal.y, escalaOriginal.z); // mira a la derecha (flip)
        }
    }






}