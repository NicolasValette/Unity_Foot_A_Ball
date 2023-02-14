using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : Ball
{
    
    private int ScoreValue = 0;
    [SerializeField] 
    private TMP_Text _scoreText;
   
    [SerializeField] 
    private ScenarioData _scenario;
    [SerializeField] 
    private GameObject _wallPrefab;
    void Start()
    {

        InitJersey();
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) 
        {
            _rigidbody.AddForce(Input.GetAxis("Horizontal") * _characterData.Speed * Time.deltaTime, 0f, Input.GetAxis("Vertical") * _characterData.Speed * Time.deltaTime);
        }
    }
}
