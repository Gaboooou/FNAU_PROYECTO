using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public AudioSource tensionMusic;  // AudioSource para la m�sica de tensi�n

    private bool isChasing = false;

    private void Start()
    {
        // Opcional: empezar quieto y luego activar persecuci�n desde afuera o directamente desde aqu�
        isChasing = true;
        if (tensionMusic != null)
        {
            tensionMusic.Play();
        }
    }

    private void Update()
    {
        if (!isChasing || player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = false;              // Detener persecuci�n
            if (tensionMusic != null)
            {
                tensionMusic.Stop();        // Parar m�sica
            }

            // Aqu� puedes agregar c�digo para "atacar" o hacer lo que quieras cuando toque al jugador
            Debug.Log("Jugador atrapado!");
        }
    }
}
