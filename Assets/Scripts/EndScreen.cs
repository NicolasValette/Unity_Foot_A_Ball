using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject _team1Prefab;
    [SerializeField]
    private GameObject _team2Prefab;
    [SerializeField]
    private List<Transform> _spawnPos;
    [SerializeField]
    private TMP_Text _winText;

    private int _team1Score;
    private int _team2Score;
    // Start is called before the first frame update
    void Start()
    {
        _team1Score = PlayerPrefs.GetInt("Team1");
        _team2Score = PlayerPrefs.GetInt("Team2");
        GameObject winningMember = (_team1Score > _team2Score) ? _team1Prefab : _team2Prefab;
        for (int i = 0; i < _spawnPos.Count; i++)
        {
            if (_team1Score == _team2Score)
            {
                Instantiate(i % 2 == 0 ? _team1Prefab : _team2Prefab, _spawnPos[i].position, _spawnPos[i].rotation);
            }
            else
            {
                Instantiate(winningMember, _spawnPos[i].position, _spawnPos[i].rotation);
            }
        }
        if (_team1Score == _team2Score)
        {
            _winText.text = "Draw";
        }
        else
        {
            _winText.text = (_team1Score > _team2Score) ? "You Win !" : "You Loose !";
        }
    }
    public void ReturnToMainScreen()
    {
        MatchManager.SwitchScene?.Invoke(0);
    }
}
