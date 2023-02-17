using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject _team1Prefab;
    [SerializeField]
    private GameObject _team2Prefab;
    [SerializeField]
    private List<Transform> _spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        GameObject winningMember = MatchManager.WinningTeam == Team.Team1?_team1Prefab:_team2Prefab;
        for (int i=0;i<_spawnPos.Count;i++)
        {
            Instantiate(winningMember, _spawnPos[i].position, _spawnPos[i].rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
