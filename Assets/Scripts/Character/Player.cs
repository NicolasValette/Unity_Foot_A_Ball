using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;

public class Player : Ball
{

    private int ScoreValue = 0;
    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private ScenarioData _scenario;
    [SerializeField]
    private GameObject _wallPrefab;
    [SerializeField]
    private PlayerData _humanBehaviour;

    private Vector2 _inputDirection;


    public static event Action GamePaused;
    void Start()
    {
        _characterData = _humanBehaviour;
        InitJersey();
    }

    void FixedUpdate()
    {
        float mult = 1f;
#if UNITY_ANDROID
        mult = 2f;
#endif
        Vector3 dir = new Vector3(_inputDirection.x, 0f, _inputDirection.y);
        _rigidbody.AddForce(dir * (_characterData.Speed * mult) * Time.fixedDeltaTime);
    }

    public void OnMove(InputValue value)
    {
        _inputDirection = value.Get<Vector2>();
    }

    private void OnPause()
    {
        Debug.Log("OnPause");   
        GamePaused?.Invoke();
    }
}
