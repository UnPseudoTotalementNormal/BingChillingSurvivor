using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "StoryObject", menuName = "Story/StoryObject", order = 1)]
public class StoryObject : ScriptableObject
{
    [Header("Character Settings")]
    public StoryCharacter Character;

    [Header("Items")]
    public List<string> Items = new List<string>();

    [Header("Text")]
    [TextArea(15, 20)]
    public string StoryText = "";
    public bool CanBeSkipped = true;

    [Header("Choices")]
    public bool HasChoices = false;
    public StoryObject[] Choices;
    public string[] ChoicesText;
    public List<StoryConditionWrapper> ChoicesConditions = new List<StoryConditionWrapper>();
    public List<StoryItemWrapper> ChoicesItemChange = new List<StoryItemWrapper>();

    [Header("Next Story Settings")]
    public StoryObject NextStory;
    public bool CanClickToNext = true;
    public bool NextAutomatically = false;
    public float NextStoryInSeconds = 2;
    public bool WaitForFinishedTalking = true;

    [Header("Image")]
    public Sprite Background;

    [Header("Video")]
    [InspectorName("PlayVideo (will next on end)")] public bool PlayVideo = false;
    public VideoClip VideoClip;

    [Header("Sounds")]
    public AudioClip Music;
}