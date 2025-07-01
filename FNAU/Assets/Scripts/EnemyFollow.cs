using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; 
    public float speed = 3f; 
    public AudioSource tensionMusic;
    public ScreenFlashEffect screenFlashEffect;
    public DoorController doorController1;  
    public DoorController doorController2;  
    public float tiempoParaCerrarPuerta = 10f; 

    private bool isChasing = false;  // El enemigo empieza sin perseguir
    private bool tensionStarted = false;  // Para empezar la música de tensión
    private bool enemigoEnPasillo = false;  // Si el enemigo está en un pasillo
    private bool isEnSala = true;  // El enemigo empieza en la sala
    private float tiempoRestante;  // Tiempo para que el enemigo comience a perseguir
    private float tiempoAleatorio; // Tiempo aleatorio para que el enemigo se mueva a un pasillo

    void Start()
    {
        // Inicializamos el enemigo en la sala y esperando el tiempo aleatorio
        isChasing = false;
        tiempoRestante = tiempoParaCerrarPuerta;
        tiempoAleatorio = Random.Range(10f, 30f);  // Rango aleatorio para que el enemigo espere entre 10 y 30 segundos
    }

    void Update()
    {
        // Si el enemigo no está persiguiendo ni en el pasillo, se mueve a un pasillo aleatorio
        if (!isChasing && !enemigoEnPasillo)
        {
            MoverAPasilloAleatorio();
        }

        // Reducir el tiempo restante para que el enemigo comience a perseguir
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
        }
        else if (!isChasing && !tensionStarted)
        {
            isChasing = true;  // El enemigo comienza a perseguir al jugador
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
        if (isEnSala && !isChasing)
        {
            int pasilloRandom = Random.Range(1, 3);  // Genera un número aleatorio para elegir el pasillo

            if (pasilloRandom == 1) 
            {
                transform.position = new Vector3(5.38f, 10.53f, 0f);  // Posición del pasillo izquierdo
                enemigoEnPasillo = true;
                isEnSala = false;
            }
            else if (pasilloRandom == 2) 
            {
                transform.position = new Vector3(-6.47f, 10.77f, 0f);  // Posición del pasillo derecho
                enemigoEnPasillo = true;
                isEnSala = false;
            }
        }
    }

    // Método para regresar al enemigo a la sala
    public void RegresarASala()
    {
        if (enemigoEnPasillo)
        {
            enemigoEnPasillo = false;
            isEnSala = true;
            transform.position = new Vector3(5.38f, 10.53f, 0f);  // El enemigo regresa a la sala
            gameObject.SetActive(false);  // Desactivamos el enemigo para reiniciar su ciclo
            tiempoAleatorio = Random.Range(10f, 30f);  // Reiniciamos el tiempo aleatorio para que el enemigo espere nuevamente
        }
    }

    // Método de colisión con el jugador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = true;  // El enemigo empieza a perseguir al jugador
        }

        // Si el enemigo toca la puerta cerrada, se detiene y regresa a la sala
        if (other.CompareTag("Door") && (doorController1.puertaCerrada || doorController2.puertaCerrada))
        {
            StopMovement();  // El enemigo se detiene al tocar la puerta
            RegresarASala();  // El enemigo regresa a la sala y reinicia el ciclo
        }
    }

    // Método para saber si el enemigo está en la sala
    public bool IsEnSala()
    {
        return isEnSala;
    }

    // Método para que el jugador cierre la puerta y reinicie el cronómetro
    public void CerrarPuerta()
    {
        tiempoRestante = tiempoParaCerrarPuerta;  // Reinicia el cronómetro
        isChasing = false;  // Detenemos la persecución
        RegresarASala();  // El enemigo regresa a la sala
    }

    // Detener el movimiento del enemigo cuando la puerta está cerrada
    public void StopMovement()
    {
        isChasing = false;  // Detenemos al enemigo si está tocando la puerta
        if (tensionMusic != null && tensionMusic.isPlaying)
        {
            tensionMusic.Stop();  // Detener la música de tensión
        }
        if (screenFlashEffect != null)
        {
            screenFlashEffect.StopFlashing();  // Detener el efecto de pantalla
        }
    }
}