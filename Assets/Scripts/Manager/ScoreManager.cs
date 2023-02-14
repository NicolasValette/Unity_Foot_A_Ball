using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreTextTeam1;
    [SerializeField]
    private TMP_Text _scoreTextTeam2;
    [SerializeField]
    private TeamData _team1;
    [SerializeField]
    private TeamData _team2;

    private int[] _scores = new int[2];
    // Start is called before the first frame update
    void Start()
    {
        _scores[(int)Team.Team1] = PlayerPrefs.GetInt("Team1");
        _scores[(int)Team.Team2] = PlayerPrefs.GetInt("Team2");
        _scoreTextTeam1.color = _team1.TeamMaterial.color;
        _scoreTextTeam2.color = _team2.TeamMaterial.color;
        _scoreTextTeam1.text = $"Team 1 : {_scores[(int)Team.Team1]} ";
        _scoreTextTeam2.text = $" {_scores[(int)Team.Team2]} : Team 2";

    }

    private void OnEnable()
    {
        Target.TargetCollected += UpdateScore;
    }
    private void OnDisable()
    {
        Target.TargetCollected -= UpdateScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(Team team, Team targetTeam)
    {
        if (team == targetTeam)
        {
            _scores[((int)team)]--;
        }
        else
        {
            _scores[((int)team)]++;
        }
        PlayerPrefs.SetString("Score", "Score : " + _scores[((int)team)].ToString());
        _scoreTextTeam1.text = $"Team 1 : {_scores[(int)Team.Team1]} ";
        _scoreTextTeam2.text = $" {_scores[(int)Team.Team2]} : Team 2";

        PlayerPrefs.SetInt("Team1", _scores[(int)Team.Team1]);
        PlayerPrefs.SetInt("Team2", _scores[(int)Team.Team2]);
        if (_scores[((int)team)] == 8)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
