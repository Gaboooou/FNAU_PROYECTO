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

    public GameObject enemy;  // Asignado en el Inspector, el objeto Enemy

    private bool isChasing = false;  
    private bool tensionStarted = false; 
    private bool enemigoEnPasillo = false; 
    private bool isEnSala = true;  
    private float tiempoRestante;  
    private float tiempoAleatorio; 

    private Vector3 pasilloIzquierdaPos = new Vector3(5.38f, 10.53f, 0f); 
    private Vector3 pasilloDerechaPos = new Vector3(-6.47f, 10.77f, 0f); 

    void Start()
    {
        ResetEnemy();
    }

    void Update()
    {
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
            StopMovement();  // El enemigo se detiene
            return;
        }

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

    public void MoverAPasilloAleatorio()
    {
        if (isEnSala && !isChasing)
        {
            int pasilloRandom = Random.Range(1, 3);  // Genera un número aleatorio para elegir el pasillo

            if (pasilloRandom == 1) 
            {
                transform.position = pasilloIzquierdaPos;  // Posición del pasillo izquierdo
                enemigoEnPasillo = true;
                isEnSala = false;
            }
            else if (pasilloRandom == 2) 
            {
                transform.position = pasilloDerechaPos;  // Posición del pasillo derecho
                enemigoEnPasillo = true;
                isEnSala = false;
            }
        }
    }

    public void RegresarASala()
    {
        if (enemigoEnPasillo)
        {
            enemigoEnPasillo = false;
            isEnSala = true;
            transform.position = pasilloIzquierdaPos;  // El enemigo regresa a la sala
            enemy.SetActive(false);  // Desactivamos el enemigo

            // Reactivamos el enemigo y reiniciamos el ciclo
            Invoke(nameof(ReactivarEnemy), 2f);  // Reactivamos el enemigo después de 2 segundos
        }
    }

    private void ReactivarEnemy()
    {
        enemy.SetActive(true);  // Reactivamos el enemigo
        ResetEnemy();  // Reiniciamos todos los valores del enemigo
    }

    private void ResetEnemy()
    {
        isChasing = false;  // El enemigo deja de perseguir
        tensionStarted = false;  // La tensión no ha comenzado
        tiempoRestante = tiempoParaCerrarPuerta;  // Reiniciamos el tiempo para cerrar la puerta
        tiempoAleatorio = Random.Range(10f, 30f);  // Espera aleatoria entre 10 y 30 segundos
    }

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
            RegresarASala();  // El enemigo regresa a la sala y reinicia su ciclo
        }
    }

    public bool IsEnSala()
    {
        return isEnSala;
    }

    public void CerrarPuerta()
    {
        tiempoRestante = tiempoParaCerrarPuerta;  // Reinicia el cronómetro
        isChasing = false;  // Detenemos la persecución
        RegresarASala();  // El enemigo regresa a la sala
    }

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