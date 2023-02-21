using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ball : MonoBehaviour
{
    [SerializeField]
    protected TeamData _team;
    protected PlayerData _characterData;
    protected Rigidbody _rigidbody;

    protected bool _isHuman = false;

    public event Action<bool, Area> EnterNewArea;
    public Team CurrentTeam { get => _team.CurrentTeam; }
 

    protected void InitJersey ()
    { 
        Material teamMat = _team.TeamMaterial;
        GetComponentInChildren<MeshRenderer>().material = teamMat;
        _rigidbody = GetComponent<Rigidbody>();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        FieldArea fieldArea = other.GetComponent<FieldArea>();
        if (fieldArea != null)              // we enter in new field area
        {
            EnterNewArea?.Invoke(_isHuman, fieldArea.Zone);
        }
    }


}
