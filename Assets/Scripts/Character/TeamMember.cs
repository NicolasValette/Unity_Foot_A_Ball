using System;
using System.Collections;
using System.Collections.Generic;
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

}
