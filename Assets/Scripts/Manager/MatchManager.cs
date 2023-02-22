using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _opponent;
    [SerializeField]
    private Ejection _ejection;
    [SerializeField]
    private FieldManager _fieldManager;
    [Header("Datas")]
    [SerializeField]
    private TeamData _playerTeam;
    [SerializeField]
    private TeamData _oponnentTeam;
    [SerializeField]
    private IAData _behaviourList;
    [Header("Teams")]
    [SerializeField]
    private GameObject _playerTeamComposition;
    [SerializeField]
    private GameObject _oponnentTeamComposition;

    public static MatchManager Instance;

    public static Team WinningTeam { get; private set; } = Team.None;
    private int _team1Number;
    private int _team2Number;
    public static int HalfTimeNumber { get; set; }
    public static GameObject Player { get => Instance._player; }
    public static GameObject Opponent { get => Instance._opponent; }
    public static TeamData PlayerTeam {  get => Instance._playerTeam; }
    public static TeamData OpponentTeam { get => Instance._oponnentTeam; }
    public static PlayerData OppenentData { get => Instance._behaviourList.OpponentData; }
    public static GameObject PlayerTeamComposition { get => Instance._playerTeamComposition; }
    public static GameObject OpponentTeamComposition { get => Instance._oponnentTeamComposition; }
    public static FieldManager FieldMangr {  get => Instance._fieldManager; }
    public static Ejection Eject { get => Instance._ejection; }
    #region Events
    public static Action<int> SwitchScene;
    #endregion


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
        _team1Number = _oponnentTeam.NumberOfPlayer;
        _team2Number = _playerTeam.NumberOfPlayer;
        Debug.Log("Difficulty = " + _behaviourList.ToString());
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
        //Debug.Log("Score team1 : " + _team1Number + " Score Team2 : " + _team2Number);

        //FIN DU MATCH

        //if (_team1Number <= 0 || _team2Number <=0)
        //{
        //   NextMatch();
        //}
    }

    private void NextMatch()
    {
        HalfTimeNumber--;
        if (HalfTimeNumber <= 0)
        {
            SwitchScene?.Invoke(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        { 
            SwitchScene?.Invoke(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
