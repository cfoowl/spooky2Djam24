using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource audioSource;
    public AudioClip correct;
    public AudioClip incorrect;
    public AudioClip[] erase;
    public AudioClip[] happyGhost;
    public AudioClip[] spawnGhost;
    public AudioClip[] angryGhost;
    public AudioClip[] grabGhost;
    public AudioClip[] talkGhost;
    public AudioClip[] paper;
    public AudioClip buttonPress;
    public AudioClip Photoprint;
    public AudioClip[] touch;



    void Awake() {
        instance = this;
    }

    void PlaySound(AudioClip audioclip){
        audioSource.clip = audioclip;
        audioSource.Play();
    }
    public void PlayIncorrectSound() {
        PlaySound(incorrect);
    }
    public void PlayCorrectSound() {
        PlaySound(correct);
    }
    public void PlayEraseSound() {
        int rand = Random.Range(0, erase.Length);
        PlaySound(erase[rand]);
    }
    
    public void PlayHappyGhostSound() {
        int rand = Random.Range(0, happyGhost.Length);
        PlaySound(happyGhost[rand]);
    }
    public void PlaySpawnGhostSound() {
        int rand = Random.Range(0, spawnGhost.Length);
        PlaySound(spawnGhost[rand]);
    }
    public void PlayAngryGhostSound() {
        int rand = Random.Range(0, angryGhost.Length);
        PlaySound(angryGhost[rand]);
    }
    public void PlayGrabGhostSound() {
        int rand = Random.Range(0, grabGhost.Length);
        PlaySound(grabGhost[rand]);
    }
    public void PlayTalkGhostSound() {
        int rand = Random.Range(0, talkGhost.Length);
        PlaySound(talkGhost[rand]);
    }
    public void PlayPaperSound() {
        int rand = Random.Range(0, paper.Length);
        PlaySound(paper[rand]);
    }
    public void PlayTouchSound() {
        int rand = Random.Range(0, touch.Length);
        PlaySound(touch[rand]);
    }
    public void PlayButtonPressSound() {
        PlaySound(buttonPress);
    }
    public void PlayPhotoPrintSound() {
        PlaySound(Photoprint);
    }
}
