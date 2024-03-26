using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance;
    [SerializeField] private StoryObject _currentObject; public StoryObject CurrentObject {  get { return _currentObject; } }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TextBoxManager.Instance.SetText(_currentObject.StoryText, _currentObject.Character.FirstName);
    }
    
    public void ReceiveOrder(string order)
    {
        string fullOrder = order;
        if (order.Contains("SFX=")) //PATH, VOLUME, CATEGORY, STOP CATEGORY, DELAY
        {
            order = order.Replace("SFX=", "");
            float volume = 1;
            float delay = 0;
            string category = "none";
            string stopCategory = "N/A";

            if (OrderHasArgument(order)) volume = float.Parse(GetFirstArgumentInOrder(order).Replace(".", ",")); order = RemoveFirstArgumentInOrder(order);
            if (OrderHasArgument(order)) category = GetFirstArgumentInOrder(order); order = RemoveFirstArgumentInOrder(order);
            if (OrderHasArgument(order)) stopCategory = GetFirstArgumentInOrder(order); order = RemoveFirstArgumentInOrder(order);
            if (OrderHasArgument(order)) delay = float.Parse(GetFirstArgumentInOrder(order).Replace(".", ",")); order = RemoveFirstArgumentInOrder(order);
            order = RemoveAllArgumentsInOrder(order);

            if (stopCategory != "N/A") SoundManager.Instance.StopAllFromCategory(stopCategory);
            SoundManager.Instance.PlayAtPath("SFX/" + order, volume, 0, delay, category);
        }
        if (order.Contains("MUSIC=")) //PATH, VOLUME
        {
            order = order.Replace("MUSIC=", "");
            float volume = 1;

            if (OrderHasArgument(order)) volume = float.Parse(GetFirstArgumentInOrder(order).Replace(".", ",")); order = RemoveFirstArgumentInOrder(order);
            order = RemoveAllArgumentsInOrder(order);

            SoundManager.Instance.PlayMusicAtPath("MUSIC/" + order, volume);
        }
    }

    private bool OrderHasArgument(string order)
    {
        return order.Contains(',');
    }
    private string GetFirstArgumentInOrder(string order)
    {
        int index = order.IndexOf(',');
        order = order.Remove(0, index + 1);
        order = order.Replace(" ", "");
        if (order.Contains(','))
        {
            order = order.Remove(order.IndexOf(","), order.Length - order.IndexOf(","));
        }
        return order;
    }

    private string RemoveFirstArgumentInOrder(string order)
    {
        if (!OrderHasArgument(order)) return order;

        int index = order.IndexOf(',');
        if (order.LastIndexOf(",") == index)
        {
            order = order.Remove(index, order.Length - index);
        }
        else
        {
            int nextIndex = 0;
            for (int i = index + 1; i < order.Length; i++)
            {
                if (order[i] == ',')
                {
                    nextIndex = i;
                    break;
                }
            }
            order = order.Remove(index, nextIndex - index);
        }

        return order;
    }

    private string RemoveAllArgumentsInOrder(string order)
    {
        while (OrderHasArgument(order)) 
        {
            order = RemoveFirstArgumentInOrder(order);
        }
        return order;
    }
}
