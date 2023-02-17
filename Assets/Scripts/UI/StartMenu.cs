
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private IAData _behaviourList;
    [SerializeField]
    private TMP_Text _sliderText;
    [SerializeField]
    private Slider _slider;


    // Start is called before the first frame update

    void Start()
    {
        PlayerPrefs.SetInt("Team1", 0);
        PlayerPrefs.SetInt("Team2", 0);
        _sliderText.text = _slider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.anyKey)
        //{
        //    LoadGame();
        //}
    }

    public void LoadGame()
    {
        Debug.Log("Menu");
        
 //       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        MatchManager.HalfTimeNumber= (int)_slider.value;
        MatchManager.SwitchScene?.Invoke(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EasyDifficulty()
    {
        _behaviourList.DifficultySelected = IAData.Difficulty.Easy;
        LoadGame();
    }
    public void MediumDifficulty()
    {
        _behaviourList.DifficultySelected = IAData.Difficulty.Medium;
        LoadGame();
    }
    public void HardDifficulty()
    {
        _behaviourList.DifficultySelected = IAData.Difficulty.Hard;
        LoadGame();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void HalftTime()
    {
        _sliderText.text = _slider.value.ToString();
    }
}
