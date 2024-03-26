using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoryObject", menuName = "Story/StoryCharacter")]
public class StoryCharacter : ScriptableObject
{
    public string FirstName;

    public List<AudioClip> RambleSounds;
}