using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _playerToFollow;
    [SerializeField]
    private Transform _cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 middle = (_playerToFollow[0].transform.position + _playerToFollow[1].transform.position)/2f;
        transform.position = new Vector3(middle.x, transform.position.y, middle.z);
    }
}
