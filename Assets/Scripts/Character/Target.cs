using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    public TeamData _team;
    protected ContactPoint _point;

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
            //Score
            TargetCollected?.Invoke(ball.CurrentTeam, gameObject);
            
            
            _point = collision.GetContact(0);
            Vector3 dir = transform.position - _point.point;
            dir = new Vector3(dir.x, 0f, dir.z);
            dir.Normalize();
            dir *= MatchManager.Eject.SpeedEjection;
            Debug.Log("Dir : " + dir);
            GetComponent<Rigidbody>().AddForce(dir, ForceMode.Impulse);
           // Destroy(gameObject, 1f);
        }
    }
    public void SetTeam(TeamData dataTeam)
    {
        _team = dataTeam;
    }
}
