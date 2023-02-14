using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ball : MonoBehaviour
{
    [SerializeField]
    protected TeamData _team;
    [SerializeField]
    protected PlayerData _characterData;
    protected Rigidbody _rigidbody;
    public Team CurrentTeam { get => _team.CurrentTeam; }
 

    protected void InitJersey ()
    { 
        Material teamMat = _team.TeamMaterial;
        GetComponentInChildren<MeshRenderer>().material = teamMat;
        _rigidbody = GetComponent<Rigidbody>();
    }
    
  
}
