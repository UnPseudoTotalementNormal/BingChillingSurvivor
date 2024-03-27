using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBoxManager : MonoBehaviour
{
    public static TextBoxManager Instance;

    [SerializeField] private TextMeshProUGUI _authorText;
    [SerializeField] private TextMeshProUGUI _mainText;
    [SerializeField] private GameObject _box;

    private string _currentMainText;
    private int _currentMainTextIndex = 0;


    [SerializeField] private float _timeBeforeNextChar = 0.1f;
    private float _textTimer = 0;

    private bool _finishedTalking = false; public bool FinishedTalking { get { return _finishedTalking; } }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        _box.SetActive(!(_currentMainText == ""));
        _finishedTalking = true;
        if (_currentMainTextIndex < _currentMainText.Length)
        {
            _finishedTalking = false;
            _textTimer += Time.deltaTime;

            if (_textTimer >= _timeBeforeNextChar)
            {
                if (_currentMainText[_currentMainTextIndex] == '[')
                {
                    string order = "";
                    for (int i = _currentMainTextIndex + 1; i < _currentMainText.Length; i++)
                    {
                        if (_currentMainText[i] == ']')
                        {
                            SendOrder(order);
                            _currentMainTextIndex = i+1;
                            break;
                        }
                        else
                        {
                            order += _currentMainText[i];
                        }
                    }
                }
                else
                {
                    _mainText.text += _currentMainText[_currentMainTextIndex];
                    _currentMainTextIndex++;

                    _textTimer = 0;

                    if (SoundManager.Instance.CategoryPlayingCount("Ramble") <= 0)
                    {
                        List<AudioClip> rambles = StoryManager.Instance.CurrentObject.Character.RambleSounds;
                        CustomSound sound = new CustomSound();
                        sound.Category = "Ramble";
                        sound.b_RandomPitch = false;
                        sound.AudioClip = rambles[Random.Range(0, rambles.Count)];
                        SoundManager.Instance.Play(sound);
                    }
                }
            }
        }
    }

    public void SetText(string text, string author)
    {
        _authorText.text = author + ":";
        _mainText.text = "";
        _currentMainText = text;
        _currentMainTextIndex = 0;
    }

    public void SendOrder(string order)
    {
        StoryManager.Instance.ReceiveOrder(order);
    }
}
