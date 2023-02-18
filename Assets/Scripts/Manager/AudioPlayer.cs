using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Stop();
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
        if (buildIndex== 0)         // When the first scene is loaded, destroy this game Object
        {
            Destroy(gameObject);
        }
    }

}
