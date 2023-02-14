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
        ToPlayer
    }

    
    [SerializeField]
    private Behavior _behavior;
    [SerializeField]
    private float _speed = 200f;


    public Behavior PlayerBehavior { get { return _behavior;} }
    public float Speed { get { return _speed;} }
}
