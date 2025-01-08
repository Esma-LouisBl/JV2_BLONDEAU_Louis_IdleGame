using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip music1, music2, music3, music4, music5, music6, music7, music8, music9, music10, music11, music12;

    private AudioSource audioSource;
    private List<AudioClip> musicTracks = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Add all music tracks to the list
        musicTracks.Add(music1);
        musicTracks.Add(music2);
        musicTracks.Add(music3);
        musicTracks.Add(music4);
        musicTracks.Add(music5);
        musicTracks.Add(music6);
        musicTracks.Add(music7);
        musicTracks.Add(music8);
        musicTracks.Add(music9);
        musicTracks.Add(music10);
        musicTracks.Add(music11);
        musicTracks.Add(music12);

        PlayRandomMusic();
    }

    // Play a random track from the list
    void PlayRandomMusic()
    {

        int randomIndex = Random.Range(0, musicTracks.Count);
        audioSource.clip = musicTracks[randomIndex];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // If the music has stopped, play a new random track
        if (!audioSource.isPlaying)
        {
            PlayRandomMusic();
        }
    }
}

