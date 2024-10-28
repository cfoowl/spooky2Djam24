using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public List<AudioSource> musicSources = new List<AudioSource>();
    public float fadeDuration = 2f;
    public float masterVolume;
    private int currentMusicIndex = 1;
    void Start()
    {
        instance = this;
        for(int i = 0; i < musicSources.Count; i++) {
            musicSources[i] = transform.GetChild(i).GetComponent<AudioSource>();
            musicSources[i].Play();
            musicSources[i].loop = true;
            musicSources[i].volume = 0;
        }
        musicSources[0].volume = masterVolume;
        musicSources[currentMusicIndex].volume = masterVolume;
    }

    
    public void changeVolume() {
        musicSources[0].volume = masterVolume;
        musicSources[currentMusicIndex].volume = masterVolume;
    }
    public void ChangBGM(int index) {
        if (currentMusicIndex != index) {
            StartCoroutine(FadeMusic(currentMusicIndex, index));
        }
    }

    private IEnumerator FadeMusic(int oldSource, int newSource)
    {
        musicSources[newSource].volume = 0f;

        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float progress = timer / fadeDuration;

            musicSources[oldSource].volume = Mathf.Lerp(masterVolume, 0f, progress);
            musicSources[newSource].volume = Mathf.Lerp(0f, masterVolume, progress);

            yield return null;
        }
        musicSources[oldSource].volume = 0;
        currentMusicIndex = newSource;
    }
}
