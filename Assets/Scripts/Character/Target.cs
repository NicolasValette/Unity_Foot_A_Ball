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
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            TargetCollected?.Invoke(ball.CurrentTeam, gameObject);
            
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            TargetCollected?.Invoke(ball.CurrentTeam, gameObject);
            Vector3 dir = MatchManager.Eject.GetRandomEjectionPos() - transform.position;
            
            dir *= MatchManager.Eject.SpeedEjection;
                Debug.Log("Dir : " + dir);
            GetComponent<Rigidbody>().AddForce(dir, ForceMode.Impulse);
            Destroy(gameObject, 1f);
        }
    }
    public void SetTeam(TeamData dataTeam)
    {
        _team = dataTeam;
    }
}
