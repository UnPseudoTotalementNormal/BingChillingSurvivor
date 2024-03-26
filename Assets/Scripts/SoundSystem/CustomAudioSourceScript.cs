using UnityEngine;

public class CustomAudioSourceScript : MonoBehaviour
{
    private AudioSource _audioSource;

    private bool _hasPlayed = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        CheckAudioSourceDestroy();
    }

    private void CheckAudioSourceDestroy()
    {
        if (!_audioSource.isPlaying)
        {
            if (_hasPlayed)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            _hasPlayed = true;
        }
    }

    private void OnDestroy()
    {
        SoundManager.Instance.CurrentAudioSources.Remove(gameObject);
    }
}
