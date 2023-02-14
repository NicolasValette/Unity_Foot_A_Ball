using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Team1,
    Team2
}
[CreateAssetMenu(menuName ="Data/New Team")]
public class TeamData : ScriptableObject
{
    [SerializeField]
    private Team _team;
    [SerializeField]
    private Material _teamMaterial;

    public Material TeamMaterial { get => _teamMaterial; }
    public Team CurrentTeam { get => _team; }
    
}
