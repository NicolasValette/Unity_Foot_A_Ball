using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{

    public TeamData _team;

    public static event Action<Team, GameObject> TargetCollected;
    public Team ActualTeam { get => _team.CurrentTeam; }

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Boum");
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            TargetCollected?.Invoke(ball.CurrentTeam, gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bim");
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            TargetCollected?.Invoke(ball.CurrentTeam, gameObject);
            Destroy(gameObject);
        }
    }

    public void SetTeam(TeamData dataTeam)
    {
        _team = dataTeam;
    }
}
