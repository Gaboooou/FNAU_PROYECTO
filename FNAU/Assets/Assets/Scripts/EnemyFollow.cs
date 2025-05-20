using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public AudioSource tensionMusic;  // AudioSource para la música de tensión

    private bool isChasing = false;

    private void Start()
    {
        // Opcional: empezar quieto y luego activar persecución desde afuera o directamente desde aquí
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
            isChasing = false;              // Detener persecución
            if (tensionMusic != null)
            {
                tensionMusic.Stop();        // Parar música
            }

            // Aquí puedes agregar código para "atacar" o hacer lo que quieras cuando toque al jugador
            Debug.Log("Jugador atrapado!");
        }
    }
}
