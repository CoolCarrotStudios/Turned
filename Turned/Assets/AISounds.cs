using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AISounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] zombieSFX;
    [SerializeField] private AudioClip[] footstepSFX;
    [SerializeField] private AudioClip[] attackSFX;
    [SerializeField] private AudioClip[] hurtSFX;
    [SerializeField] private AudioClip[] deadSFX;

    private bool playingSound;
    
    private AudioSource audio;
    

    // Start is called before the first frame update
    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayZombieSound()
    {
        StartCoroutine(PlaySound(zombieSFX));
    }
    public void PlayFootstepsSound()
    {
        StartCoroutine(PlaySound(footstepSFX));
    }

    public void PlayHurtSound()
    {
        StartCoroutine(PlaySound(hurtSFX));
    }
    
    public void PlayAttackSound()
    {
        StartCoroutine(PlaySound(attackSFX));
    }
    
    public void PlayDeadSound()
    {
        StartCoroutine(PlaySound(deadSFX));
    }
    
    private IEnumerator PlaySound(AudioClip[] soundToPlay)
    {
        if (playingSound) yield return null;
        
        playingSound = true;
        if (soundToPlay != null)
        {
            int index = Random.Range(0, soundToPlay.Length);
            float pitch = Random.Range(0.9f, 1.2f);
            audio.pitch = pitch;
            audio.PlayOneShot(soundToPlay[index]);
            yield return new WaitForSeconds(soundToPlay[index].length);
        }

        playingSound = false;
    }
}