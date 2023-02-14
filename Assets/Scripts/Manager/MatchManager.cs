using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private int _Team1Number;
    [SerializeField]
    private int _Team2Number;
    [SerializeField]
    private TeamData _team1;
    [SerializeField]
    private TeamData _team2;
    public static MatchManager Instance;
    
    private int[] _scores = new int[2];
    public static GameObject Player { get => Instance._player; }

    private void OnEnable()
    {
        Target.TargetCollected += UpdateTarget;
    }
    private void OnDisable()
    {
        Target.TargetCollected -= UpdateTarget;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void UpdateTarget(Team team, Team targetTeam)
    {
        if (targetTeam == Team.Team1)
        {
            _Team1Number--;
        }
        else if (targetTeam == Team.Team2)
        {
            _Team2Number--;
        }





      
        if (_Team1Number <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (_Team2Number <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
