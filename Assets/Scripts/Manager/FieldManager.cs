using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    [Header("Area 1")]
    [SerializeField]
    private Transform _positionArea1;
    [Header("Area 2")]
    [SerializeField]
    private Transform _positionArea2;
    [Header("Area 3")]
    [SerializeField]
    private Transform _positionArea3;
    [Header("Area 4")]
    [SerializeField]
    private Transform _positionArea4;


    public Transform GetOppositeArea(Area a)
    {
        if (Area.Area1 == a)
        {
            return _positionArea4;
        }
        else if (Area.Area2 == a)
        {
            return _positionArea3;
        }
        else if (Area.Area3 == a)
        {
            return _positionArea2;
        }
        else if (Area.Area4 == a)
        {
            return _positionArea1;
        }
        return null;
    }


}
