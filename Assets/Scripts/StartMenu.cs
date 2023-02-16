
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Team1", 0);
        PlayerPrefs.SetInt("Team2", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            LoadGame();
        }
    }

    public void LoadGame()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
