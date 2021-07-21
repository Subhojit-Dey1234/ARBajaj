using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private bool applicationIsQuitting = false;
    public static AudioManager Instance;
    public List<Sound> sounds;

    private void Awake()
    {
        if(applicationIsQuitting)
        {
            Instance = null;
        }
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = s.loop;

        }
    }
    public void PlaySound(string clipName)
    {
        var audio = sounds.First(s => s.name.Equals(clipName));
        if (audio == null)
        {
            Debug.LogWarning("Sound Does not exist");
        }
        else
        {
            audio.source.Play();
        }

    }
    private void OnDestroy()
    {
        applicationIsQuitting = true;
    }
}
