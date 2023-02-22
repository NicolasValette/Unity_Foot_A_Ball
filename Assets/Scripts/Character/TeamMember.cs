using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TeamMember : Target
{
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
    private void OnDisable()
    {
        if (ActualTeam == Team.Team1)
        {
            MatchManager.Player.GetComponent<Player>().EnterNewArea -= ChangeTarget;
        }
        else
        {
            MatchManager.Opponent.GetComponent<Opponent>().EnterNewArea -= ChangeTarget;
        }
    }
    private void Update()
    {
        //_agent.destination = _goal.position;
        _agent.SetDestination(_goal.position);
        //_agent.speed = 3.5f;
        
        Debug.DrawLine(transform.position, _agent.destination, Color.magenta);
    }
    public void ChangeTarget(bool isHuman, Area area)
    {
        Debug.Log("Event Change Target, human : " + area);
        _goal = MatchManager.FieldMangr.GetOppositeArea(area);
        //StartCoroutine(StopVelocity());
    }

    //public IEnumerator StopVelocity ()
    //{
    //    yield return new WaitForSeconds(2f);
    //    GetComponent<Rigidbody>().velocity = Vector3.zero;
    //}
}
