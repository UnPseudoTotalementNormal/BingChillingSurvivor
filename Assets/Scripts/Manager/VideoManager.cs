using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public static VideoManager Instance;

    private VideoPlayer _videoPlayer; public VideoPlayer VideoPlayer { get { return _videoPlayer; } }

    public UnityEvent FinishedPlayingEvent;

    private void Awake()
    {
        Instance = this;
        _videoPlayer = GetComponent<VideoPlayer>();
    }

    public void PlayVideo(VideoClip videoClip)
    {
        _videoPlayer.enabled = true;
        _videoPlayer.clip = videoClip;
        _videoPlayer.Play();
        Invoke("StopPlaying", (float)videoClip.length);
    }

    private void StopPlaying()
    {
        _videoPlayer.enabled = false;
        FinishedPlayingEvent?.Invoke();
    }
}
