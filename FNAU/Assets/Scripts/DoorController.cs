using UnityEngine;

public class DoorController : MonoBehaviour
{
    private SpriteRenderer puertaSprite;
    public Collider2D colliderBloqueador;
    public KeyCode teclaCerrar = KeyCode.E;
    public float duracionCierre = 5f;

    private bool jugadorCerca = false;
    private bool puertaCerrada = false;

    void Start()
    {
        puertaSprite = GetComponent<SpriteRenderer>();
        puertaSprite.enabled = false;
        colliderBloqueador.enabled = false;
    }

    void Update()
    {
        if (jugadorCerca && !puertaCerrada && Input.GetKeyDown(teclaCerrar))
        {
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
}
