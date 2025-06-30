using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public AudioSource tensionMusic;
    public ScreenFlashEffect screenFlashEffect;
    public CameraImageToggle cameraToggle;  // Referencia al script CameraImageToggle
    public DoorController doorController1;  // Primera puerta
    public DoorController doorController2;  // Segunda puerta
    public float tiempoParaCerrarPuerta = 10f;  // El tiempo para cerrar la puerta

    private bool isChasing = false;  // Empieza sin perseguir
    private bool tensionStarted = false;
    private bool enemigoEnPasillo = false;
    private bool isEnSala = true;  // El enemigo empieza en la sala
    private float tiempoRestante;  // Para almacenar el tiempo restante para que el enemigo empiece a perseguir

    void Start()
    {
        // El enemigo empieza en la sala, pero no persigue al jugador
        isChasing = false; 
        gameObject.SetActive(true);  // Aseguramos que el GameObject del enemigo esté activo al inicio

        tiempoRestante = tiempoParaCerrarPuerta;  // Inicializamos el tiempo restante
    }

    void Update()
    {
        // Si el jugador no ha cerrado la puerta en el tiempo permitido, empieza la persecución
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;  // Reducir el tiempo restante cada frame
        }
        else if (!isChasing && !tensionStarted)  // Si el tiempo ha pasado y el enemigo aún no persigue
        {
            isChasing = true;  // Comienza a perseguir al jugador
            Debug.Log("El enemigo comienza a perseguir al jugador por no cerrar la puerta.");
        }

        // Si la puerta está cerrada, el enemigo no puede moverse hacia ella
        if (doorController1.puertaCerrada || doorController2.puertaCerrada)
        {
            StopMovement();
            return;  // Si la puerta está cerrada, no se mueve el enemigo
        }

        // Comportamiento de persecución solo si está persiguiendo
        if (isChasing)
        {
            if (!tensionStarted)
            {
                tensionStarted = true;
                if (tensionMusic != null && !tensionMusic.isPlaying)
                    tensionMusic.Play();
                if (screenFlashEffect != null)
                    screenFlashEffect.StartFlashing();
            }

            if (player != null)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }

    // Método para mover al enemigo a un pasillo aleatorio
    public void MoverAPasilloAleatorio()
    {
        int pasilloRandom = Random.Range(1, 3); 
        enemigoEnPasillo = true;
        isEnSala = false;  // El enemigo se mueve a un pasillo
        cameraToggle.ActivarPasillo(pasilloRandom);  // Cambiar la imagen del pasillo
    }

    public void RegresarASala()
    {
        if (enemigoEnPasillo)
        {
            enemigoEnPasillo = false;
            isEnSala = true;  // El enemigo regresa a la sala
            cameraToggle.RegresarASala();  // Regresa a la imagen de la sala
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = true;  // Empieza a perseguir al jugador
            Debug.Log("Jugador atrapado!");
        }
    }

    // Método para saber si el enemigo está en la sala
    public bool IsEnSala()
    {
        return isEnSala;
    }

    // Método que permite al jugador cerrar la puerta, reiniciando el cronómetro
    public void CerrarPuerta()
    {
        tiempoRestante = tiempoParaCerrarPuerta;  // Reiniciar el cronómetro
        isChasing = false;  // Detener la persecución
        Debug.Log("La puerta ha sido cerrada a tiempo.");
    }

    // Detener el movimiento del enemigo (cuando la puerta está cerrada)
    public void StopMovement()
    {
        isChasing = false;
        Debug.Log("El enemigo está detenido por la puerta cerrada.");
    }
}