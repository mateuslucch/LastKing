using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] AudioClip[] musicList;

    AudioSource myAudioSource;
    int singleMusic = 0;

    private void Awake()
    {
        int playerMusic = FindObjectsOfType<MusicPlayer>().Length;
        if (playerMusic > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        myAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ChangeSong();
    }

    public void ChangeSong()
    {
        PlayMusic();
    }

    private void PlayMusic()
    {
        myAudioSource.clip = musicList[singleMusic];
        myAudioSource.Play();
        StartCoroutine(PlayNextSong());
    }

    IEnumerator PlayNextSong()
    {
        yield return new WaitForSeconds(musicList[singleMusic].length + 1);
        singleMusic++;
        if (singleMusic > 1)
        {
            singleMusic = 0;
        }
        ChangeSong();
    }
}
