using UnityEngine;

public class ItemFeedbackText : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
    }
}
