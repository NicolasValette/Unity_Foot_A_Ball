using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Area
{
    Area1,
    Area2,
    Area3,
    Area4
}
public class FieldArea : MonoBehaviour
{
    [SerializeField]
    private Area _areaField;

    public Area Zone { get => _areaField; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            //Debug.Log("Enter Area " + _areaField.ToString());
        }
    }

}
