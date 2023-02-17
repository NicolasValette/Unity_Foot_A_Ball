using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/New IAData List")]
public class IAData : ScriptableObject
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
    [SerializeField]
    private List<PlayerData> _IABehaviourList;

    public Difficulty DifficultySelected { get; set; } = 0;
    public PlayerData OpponentData { get => _IABehaviourList[(int)DifficultySelected]; }
    public override string ToString()
    {
        return DifficultySelected.ToString();
    }
}
