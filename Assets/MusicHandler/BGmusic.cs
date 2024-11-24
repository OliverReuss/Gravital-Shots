using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGmusic : MonoBehaviour
{
    public static BGmusic instance;

    private AudioSource audioSource;

    public AudioClip menuMusic;
    public AudioClip stage1Music;
    public AudioClip stage2Music;
    public AudioClip stage3Music;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            audioSource = GetComponent<AudioSource>();
        }
    }

    void OnEnable()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        if (newScene.name == "Menu" && menuMusic != null)
        {
            PlayMusic(menuMusic);
        }

        else if (newScene.name == "Options" && menuMusic != null)
        {
            PlayMusic(menuMusic);
        }

        else if (newScene.name == "Stage1" && stage1Music != null)
        {
            PlayMusic(stage1Music);
        }

        else if (newScene.name == "Stage2" && stage2Music != null)
        {
            PlayMusic(stage2Music);
        }

        else if (newScene.name == "Stage3" && stage3Music != null)
        {
            PlayMusic(stage3Music);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip == clip)
        {
            return; // Prevent restarting the same clip
        }

        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}
