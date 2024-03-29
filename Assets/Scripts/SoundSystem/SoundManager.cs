using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _musicSource;

    public Dictionary<GameObject, Dictionary<string, string>> CurrentAudioSources = new Dictionary<GameObject, Dictionary<string, string>>();

    private void Awake()
    {
        Instance = this;
    }

    public void PlayMusicAtPath(string path, float volume = 1)
    {
        AudioClip newClip = Resources.Load<AudioClip>(path);
        if (_musicSource.clip != newClip)
        {
            _musicSource.volume = volume;
            _musicSource.clip = newClip;
            _musicSource.Play();
        }
    }

    public void PlayAtPath(string path, float volume = 1, float randomness = 0f, float delay = 0, string category = "none")
    {
        AudioClip newClip = Resources.Load<AudioClip>(path);
        CustomSound sound = new CustomSound();
        sound.AudioClip = newClip;
        sound.b_RandomPitch = true;
        sound.MaxPitchRandomness = randomness;
        sound.Volume = volume;
        sound.Delay = delay;
        sound.Category = category;
        Play(sound);
    }

    public GameObject Play(CustomSound newCustomSound)
    {
        GameObject newObject = new GameObject();
        AudioSource audioSource = newObject.AddComponent<AudioSource>();
        newObject.AddComponent<CustomAudioSourceScript>();
        audioSource.clip = newCustomSound.AudioClip;
        audioSource.loop = newCustomSound.b_IsLoop;
        audioSource.volume = newCustomSound.Volume;
        if (newCustomSound.b_IsLocated)
        {
            audioSource.maxDistance = newCustomSound.MaxDistance;
        }
        else
        {
            audioSource.maxDistance = 9999999999;
        }
        if (newCustomSound.b_RandomPitch)
        {
            audioSource.pitch = 1 + Random.Range(-newCustomSound.MaxPitchRandomness, newCustomSound.MaxPitchRandomness);
        }
        audioSource.playOnAwake = false;
        audioSource.PlayDelayed(newCustomSound.Delay);

        newObject.transform.position = newCustomSound.AudioPosition;

        CurrentAudioSources.Add(newObject, new Dictionary<string, string>());

        CurrentAudioSources.TryGetValue(newObject, out Dictionary<string, string> dic);
        dic.Add("Category", newCustomSound.Category);

        return newObject;
    }

    public int CategoryPlayingCount(string category)
    {
        int count = 0;
        Dictionary<GameObject, Dictionary<string, string>>.KeyCollection sourceKeys = CurrentAudioSources.Keys;
        foreach (GameObject sourceObject in sourceKeys)
        {
            if (CurrentAudioSources[sourceObject]["Category"] == category)
            {
                count++;
            }
        }
        return count;
    }

    public void StopAllFromCategory(string category)
    {
        Dictionary<GameObject, Dictionary<string, string>>.KeyCollection sourceKeys = CurrentAudioSources.Keys;
        foreach (GameObject sourceObject in sourceKeys)
        {
            if (CurrentAudioSources[sourceObject]["Category"] == category)
            {
                Destroy(sourceObject);
            }
        }
    }
}
