using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    public enum MixerGroup
    {
        Master,
        Music

    }
    [SerializeField]
    private AudioMixer _mixer;

    public static AudioPlayer Instance = null;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        MatchManager.SwitchScene += DestoyOnTitleScreen;
    }
    private void OnDisable()
    {
        MatchManager.SwitchScene -= DestoyOnTitleScreen;
    }

    public void DestoyOnTitleScreen(int buildIndex)
    {
        if (buildIndex == 0)         // When the first scene is loaded, destroy this game Object
        {
            Destroy(gameObject);
        }
    }
    public void SetVolume(MixerGroup group, float volume)
    {
        string parameter = "";
        if (group == MixerGroup.Master)
        {
            parameter = "MasterVolume";
        }
        else if (group == MixerGroup.Music)
        {
            parameter = "MusicVolume";
        }
        _mixer.SetFloat(parameter, volume);
        PlayerPrefs.SetFloat(parameter, volume);
    }

}
