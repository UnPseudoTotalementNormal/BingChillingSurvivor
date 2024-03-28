using UnityEngine;

public class ItemFeedbackManager : MonoBehaviour
{
    public static ItemFeedbackManager Instance;

    [SerializeField] private GameObject _itemFeedbackText;

    private void Awake()
    {
        Instance = this;
    }

    public void SendFeedback(string feedbackText)
    {
        print(feedbackText);
    }
}
