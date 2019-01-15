using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioON : MonoBehaviour
{
    public Button btnOn;
    public Button btnOff;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        btnOn = GetComponent<Button>();
        btnOff = GetComponent<Button>();

        btnOn.onClick.AddListener(() => PlayAudio());
        btnOff.onClick.AddListener(() => StopAudio());
    }

    void PlayAudio()
    {
        audioSource.volume = 0.5f;
    }

    void StopAudio()
    {
        audioSource.volume = 0f;
    }
}