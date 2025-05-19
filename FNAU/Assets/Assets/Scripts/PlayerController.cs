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
    }

    void Update()
    {
        // Entrada en ambos ejes
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // Movimiento calculado
        Vector3 movimiento = new Vector3(inputX, inputY, 0f).normalized * velocidad * Time.deltaTime;

        // Aplicar movimiento
        transform.position += movimiento;

        // Animación (velocidad general)
        animator.SetFloat("movement", movimiento.magnitude * velocidad);

        // Voltear sprite horizontalmente si hay movimiento en X
        if (inputX < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(escalaOriginal.x), escalaOriginal.y, escalaOriginal.z);
        }
        else if (inputX > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(escalaOriginal.x), escalaOriginal.y, escalaOriginal.z);
        }
    }
}