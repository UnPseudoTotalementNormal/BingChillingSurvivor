using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "StoryObject", menuName = "Story/StoryObject", order = 1)]
public class StoryObject : ScriptableObject
{
    [Header("Character Settings")]
    public StoryCharacter Character;

    [Header("Text")]
    [TextArea(15, 20)]
    public string StoryText = "";

    [Header("Choices")]
    public bool HasChoices = false;

    [Header("Next Story Settings")]
    public StoryObject NextStory;
    public bool CanClickToNext = true;
    public float NextStoryInSeconds = 2;
    public bool NextAutomatically = false;

    [Header("Video")]
    [InspectorName("PlayVideo (will next on end)")] public bool PlayVideo = false;
    public VideoClip VideoClip;
}