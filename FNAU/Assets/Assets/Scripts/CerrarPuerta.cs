using UnityEngine;

public class CerrarPuerta : MonoBehaviour
{
    public Collider2D puertaCollider;

    public void Cerrar()
    {
        if (puertaCollider != null)
        {
            puertaCollider.isTrigger = false; // Se vuelve colisionable
            Debug.Log("Puerta cerrada.");
        }
    }
}

