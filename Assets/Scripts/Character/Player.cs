using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using Newtonsoft.Json.Linq;

public class Player : Ball
{
    
    private int ScoreValue = 0;
    [SerializeField] 
    private TMP_Text _scoreText;
   
    [SerializeField] 
    private ScenarioData _scenario;
    [SerializeField] 
    private GameObject _wallPrefab;

    private Vector2 _inputDirection;

    PlayerInput p;
    void Start()
    {
        InitJersey();
    }

    void FixedUpdate()
    {
        Vector3 dir = new Vector3(_inputDirection.x, 0f, _inputDirection.y);
        _rigidbody.AddForce(dir * _characterData.Speed * Time.fixedDeltaTime);
    }

    public void OnMove(InputValue value)
    {
        _inputDirection = value.Get<Vector2>();
    }
}
