using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundManager : MonoBehaviour
{
    public static MenuSoundManager instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip MusicaPrincipal;
    public List<AudioClip> sfxClips;

    private Dictionary<string, AudioClip> sfxDict;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            sfxDict = new Dictionary<string, AudioClip>();
            foreach (AudioClip clip in sfxClips)
            {
                sfxDict[clip.name] = clip;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Cambié el nombre de la función para que sea relacionado con el menú
    public void ActivarEfectoMenu(string name)
    {
        if (sfxDict.ContainsKey(name))
        {
            sfxSource.PlayOneShot(sfxDict[name]);
        }
        else
        {
            Debug.LogWarning("No se encontró el SFX del menú: " + name);
        }
    }

    // Cambié el nombre de la función para que sea relacionado con el menú
    public void ReproducirMusicaMenu(AudioClip music)
    {
        if (musicSource == null)
        {
            Debug.LogWarning("No hay AudioSource asignado para la música del menú.");
            return;
        }

        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.Play();
    }

    // Cambié el nombre de la función para que sea relacionado con el menú
    public void PararMusicaMenu()
    {
        musicSource.Stop();
    }
}
