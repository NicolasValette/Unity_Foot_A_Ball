using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejection : MonoBehaviour
{

    [SerializeField]
    private List<Transform> _ejectionsPostitions;
    [SerializeField]
    private float _speedEject = 50f;

    public float SpeedEjection { get => _speedEject; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 GetRandomEjectionPos()
    {
        return _ejectionsPostitions[Random.Range(0, _ejectionsPostitions.Count)].position;
    }
}
