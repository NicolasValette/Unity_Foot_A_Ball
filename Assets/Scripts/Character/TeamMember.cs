using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TeamMember : Target
{
    [SerializeField]
    private Transform _goal;
    public static event Action PlayerDead;
    public bool IsTargeted { get; set; }
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = _goal.position;
        if (ActualTeam == Team.Team1)
        {
            MatchManager.Player.GetComponent<Player>().EnterNewArea += ChangeTarget;
        }
        else
        {
            MatchManager.Opponent.GetComponent<Opponent>().EnterNewArea += ChangeTarget;
        }
    }
    private void OnDestroy()
    {
        if (IsTargeted)
        {
            Debug.Log("Player Dead");
            PlayerDead?.Invoke();
        }
    }
    private void Update()
    {
        _agent.destination = _goal.position;
    }
    public void ChangeTarget(bool isHuman, Area area)
    {
        Debug.Log("Event Change Target, human : " + area);
        _goal = MatchManager.FieldMangr.GetOppositeArea(area);
    }
}
