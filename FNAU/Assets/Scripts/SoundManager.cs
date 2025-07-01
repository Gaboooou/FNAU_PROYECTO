using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

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

    public void ActivarEfecto(string name)
    {
        if (sfxDict.ContainsKey(name))
        {
            sfxSource.PlayOneShot(sfxDict[name]);
        }
        else
        {
            Debug.LogWarning("No se encontró el SFX: " + name);
        }
    }

    public void ReproducirMusica(AudioClip music)
{
    if (musicSource == null)
    {
        Debug.LogWarning("No hay AudioSource asignado para la música.");
        return;
    }

    musicSource.clip = music;
    musicSource.loop = true;
    musicSource.Play();
}

    public void PararMusica()
    {
        musicSource.Stop();
    }
}
