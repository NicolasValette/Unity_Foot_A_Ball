using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/New player")]
public class PlayerData : ScriptableObject
{
  public enum Behavior
    {
        Human,
        Random,
        ToPlayer,
        ToTarget
    }

    
    [SerializeField]
    private Behavior _behavior;
    [SerializeField]
    private float _speed = 200f;
    [SerializeField]
    private float _waitingTimeBetweenForce = 3f;
    [SerializeField]
    private float _waitingTimeBetweenTarget = 1f;
    [SerializeField]
    private float _waitingBeforeNewTarget;


    public Behavior PlayerBehavior { get => _behavior;} 
    public float Speed { get => _speed;} 
    public float WaitingTimeBetweenForce { get => _waitingTimeBetweenForce; }
    public float WaitingTimeBetweenTarget { get => _waitingTimeBetweenTarget; }
}
