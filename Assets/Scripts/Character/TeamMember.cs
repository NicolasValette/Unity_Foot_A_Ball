using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMember : Target
{
    public static event Action PlayerDead;
    public bool IsTargeted { get; set; }

    private void OnDestroy()
    {
        if (IsTargeted)
        {
            Debug.Log("Player Dead");
            PlayerDead?.Invoke();
        }
    }

}
