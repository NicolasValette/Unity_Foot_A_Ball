
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
    private Slider _matchSlider;
    [SerializeField]
    private Slider _masterSlider;
    [SerializeField]
    private Slider _musicSlider;
    [SerializeField]
    private AudioPlayer _player;
    [SerializeField]
    private GameObject _settingsMenu;


    // Start is called before the first frame update

    void Start()
    {
        PlayerPrefs.SetInt("Team1", 0);
        PlayerPrefs.SetInt("Team2", 0);
        _sliderText.text = _matchSlider.value.ToString();

        //Set volume settings
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        _player.SetVolume(AudioPlayer.MixerGroup.Music, musicVolume);
        _player.SetVolume(AudioPlayer.MixerGroup.Master, masterVolume);
        _musicSlider.value = musicVolume;
        _masterSlider.value = masterVolume;
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
        MatchManager.HalfTimeNumber= (int)_matchSlider.value;
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
        _sliderText.text = _matchSlider.value.ToString();
    }
    public void SetMusicVolume()
    {
        _player.SetVolume(AudioPlayer.MixerGroup.Music, _musicSlider.value);
    }
    public void SetMasterVolume()
    {
        _player.SetVolume(AudioPlayer.MixerGroup.Master, _masterSlider.value);
    }
    public void SettingsMenu()
    {
        _settingsMenu.SetActive(!_settingsMenu.activeInHierarchy);
    }
}
