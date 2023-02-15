using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTarget : Target
{

    [SerializeField]
    private GameObject _playerToFollow;
    // Start is called before the first frame update
    void Start()
    {
        Material teamMat = _team.TeamMaterial;
        GetComponent<MeshRenderer>().material = teamMat;
    }
}
