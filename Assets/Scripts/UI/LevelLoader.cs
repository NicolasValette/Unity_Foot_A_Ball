using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{



    [SerializeField]
    private Animator _transition;
    [SerializeField]
    private float _transitionTime;

    private void OnEnable()
    {
        MatchManager.SwitchScene += LoadGame;
    }
    private void OnDisable()
    {
        MatchManager.SwitchScene -= LoadGame;
    }
    public void LoadGame(int buildIndex)
    {
        StartCoroutine(LoadLevel(buildIndex));
    }
    IEnumerator LoadLevel(int buildIndex)
    {
        Debug.Log("Hello");
        _transition.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);

        SceneManager.LoadScene(buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
