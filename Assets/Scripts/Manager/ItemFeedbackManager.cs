using TMPro;
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
        if (_itemFeedbackText)
        {
            GameObject newFeedback = Instantiate(_itemFeedbackText, transform.position + (-transform.up * 2), Quaternion.identity, transform);
            newFeedback.GetComponent<TextMeshProUGUI>().text = feedbackText;
            Destroy(newFeedback, 2);
        }
    }
}
