using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] playlist;

    private AudioSource audio;


    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlaySong());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PlaySong()
    {
        int randomSong = Random.Range(0, playlist.Length);
        audio.PlayOneShot(playlist[randomSong]);
        yield return new WaitForSeconds(playlist[randomSong].length);
        StartCoroutine(PlaySong());
    }
}
