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
    public float tiempoParaCerrarPuerta = 10f;

    private bool isChasing = false;  // Empieza sin perseguir
    private bool tensionStarted = false;
    private bool enemigoEnPasillo = false;
    private bool isEnSala = true;  // El enemigo empieza en la sala

    void Start()
    {
        // Eliminar la llamada a RegresarASala() aquí
        // No es necesario llamar a RegresarASala() en Start porque
        // No queremos que la cámara se active al principio
        isChasing = false; // El enemigo no está persiguiendo al jugador al inicio
        gameObject.SetActive(true);  // Aseguramos que el GameObject del enemigo esté activo al inicio
    }

    void Update()
    {
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
}
