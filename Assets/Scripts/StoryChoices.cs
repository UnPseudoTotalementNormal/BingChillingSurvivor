using UnityEngine;

[CreateAssetMenu(fileName = "StoryChoice", menuName = "Story/StoryChoice")]
public class StoryChoice : ScriptableObject
{
    [Header("Text")]
    [TextArea(15, 20)]
    public string ChoiceText = "";

    [Header("Next Story Settings")]
    public bool ChangeNextStory = true;
    public StoryObject ChoiceNextStory;
}