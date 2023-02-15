using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    [SerializeField]
    protected TeamData _team;

    public static event Action<Team, Team> TargetCollected;

   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Boum");
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            TargetCollected?.Invoke(ball.CurrentTeam, _team.CurrentTeam);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bim");
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            TargetCollected?.Invoke(ball.CurrentTeam, _team.CurrentTeam);
            Destroy(gameObject);
        }
    }
}
