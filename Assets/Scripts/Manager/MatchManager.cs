using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private TeamData _team1;
    [SerializeField]
    private TeamData _team2;
    public static MatchManager Instance;

    private int _team1Number;
    private int _team2Number;
    public static GameObject Player { get => Instance._player; }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        _team1Number = _team1.NumberOfPlayer;
        _team2Number = _team2.NumberOfPlayer;
    }
    private void OnEnable()
    {
        Target.TargetCollected += UpdateTarget;
    }
    private void OnDisable()
    {
        Target.TargetCollected -= UpdateTarget;
        Instance = null;
    }
    public void UpdateTarget(Team team, GameObject member)
    {
        Team targetTeam = member.GetComponent<Target>().ActualTeam;
        if (targetTeam == Team.Team1)
        {
            _team1Number--;
        }
        else if (targetTeam == Team.Team2)
        {
            _team2Number--;
        }
        Debug.Log("Score team1 : " + _team1Number + " Score Team2 : " + _team2Number);
        if (_team1Number <= 0)
        {
            Debug.Log("UpdateTarget");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (_team2Number <= 0)
        {
            Debug.Log("UpdateTarget");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
