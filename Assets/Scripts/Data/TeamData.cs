using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Team1,
    Team2,
    None
}
[CreateAssetMenu(menuName ="Data/New Team")]
public class TeamData : ScriptableObject
{
    [SerializeField]
    private Team _team;
    [SerializeField]
    private Material _teamMaterial;
    [SerializeField]
    private GameObject _teamMemberPrefab;
    [SerializeField]
    private int _numberOfPlayer;

    public Material TeamMaterial { get => _teamMaterial; }
    public Team CurrentTeam { get => _team; }
    public GameObject TeamMemberPrefab { get => _teamMemberPrefab; } 
    public int NumberOfPlayer { get => _numberOfPlayer; } 
    
}
