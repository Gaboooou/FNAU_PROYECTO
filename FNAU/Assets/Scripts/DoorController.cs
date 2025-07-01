using UnityEngine;

public class DoorController : MonoBehaviour
{
    private SpriteRenderer puertaSprite;
    public Collider2D colliderBloqueador;
    public KeyCode teclaCerrar = KeyCode.E;
    public float duracionCierre = 5f;

    private bool jugadorCerca = false;
    public bool puertaCerrada = false;

    void Start()
    {
        puertaSprite = GetComponent<SpriteRenderer>();
        puertaSprite.enabled = false;
        colliderBloqueador.enabled = false;
    }

    void Update()
    {
        // Si el jugador está cerca y presiona la tecla, cerramos la puerta
        if (jugadorCerca && !puertaCerrada && Input.GetKeyDown(teclaCerrar))
        {   
            SoundManager.instance.ActivarEfecto("Cerrar puerta");
            StartCoroutine(CerrarPuertaPorTiempo());
        }
    }

    private System.Collections.IEnumerator CerrarPuertaPorTiempo()
    {
        puertaCerrada = true;

        puertaSprite.enabled = true;
        colliderBloqueador.enabled = true;
        yield return new WaitForSeconds(duracionCierre);

        puertaSprite.enabled = false;
        colliderBloqueador.enabled = false;

        puertaCerrada = false;
        SoundManager.instance.ActivarEfecto("AbrirPuerta");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            jugadorCerca = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            jugadorCerca = false;
    }
    
    public bool IsPuertaCerrada()
    {
        return puertaCerrada;
    }
}