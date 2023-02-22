using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamComposition : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _teamMembers;
    [SerializeField]
    private TeamData _team;

    public List<GameObject> TeamMembers { get => _teamMembers; }
    public TeamData ActualTeam { get => _team; }

    private void Awake()
    {
        for (int i=0; i<TeamMembers.Count; i++)
        {
            Area area = Area.Area1;
            TeamMembers[i].GetComponent<Target>()?.SetTeam(_team);
            if (i%4 == 0)
            {
                area = Area.Area1;
            }
            else if (i % 4 == 1)
            {
                area = Area.Area2;
            }
            else if (i % 4 == 2)
            {
                area = Area.Area3;
            }
            else if (i % 4 == 3)
            {
                area = Area.Area4;
            }
            TeamMembers[i].GetComponent<TeamMember>()?.ChangeTarget(false, area);
        }
    }
    private void OnEnable()
    {
        Target.TargetCollected += RemoveMember;
    }
    private void OnDisable()
    {
        Target.TargetCollected -= RemoveMember;
    }
    public GameObject GetMember ()
    {
        if (_teamMembers.Count > 0)
        {
            return _teamMembers[Random.Range(0, _teamMembers.Count)];
        }
        return null;
    }

    public void RemoveMember(Team team, GameObject member)
    {
        if (member.GetComponent<TeamMember>().ActualTeam == _team.CurrentTeam)
        {
            _teamMembers.Remove(member);
        }
    }

}
