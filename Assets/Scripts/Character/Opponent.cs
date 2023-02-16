using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : Ball
{
    [SerializeField]
    private float _waitTime;

    private bool _isChoosing = false;

    private Vector3 direction;
    private GameObject targetToTrack;
   // private Dictionary<PlayerData.Behavior, Action> _moveMethod = new Dictionary<PlayerData.Behavior, Action>();
    private Action[] _moveMethod ;
    void Start()
    {
        _moveMethod = new Action[4];
        _moveMethod[(int)PlayerData.Behavior.Random] = RandomMove;
        _moveMethod[(int)PlayerData.Behavior.ToPlayer] = ToPlayer;
        _moveMethod[(int)PlayerData.Behavior.ToTarget] = ToTarget;
        InitJersey();
    }

    // Update is called once per frame
    void Update()
    {
        _moveMethod[(int)_characterData.PlayerBehavior]();
    }
    public IEnumerator WaitBeforeNewForce()
    {
        yield return new WaitForSeconds(_waitTime);
        _isChoosing = false;
    }


    public void RandomMove()
    {
        Debug.Log("RandomMove");
        if (!_isChoosing)
        {
            _rigidbody.velocity = Vector3.zero;
            Vector3 dir = UnityEngine.Random.onUnitSphere;
            direction = new Vector3(dir.x, transform.position.y, dir.z) - transform.position;
            direction.Normalize();
            Debug.Log(direction);
           
            _isChoosing = true;
            StartCoroutine(WaitBeforeNewForce());
        } 
        _rigidbody.AddForce(_characterData.Speed * Time.deltaTime * direction);
    }

    public void ToPlayer()
    {
        if (!_isChoosing)
        {
            direction = MatchManager.Player.transform.position - transform.position;
            direction.Normalize();
           // Debug.Log(direction);
            
            _isChoosing = true;
            StartCoroutine(WaitBeforeNewForce());
        }
        _rigidbody.AddForce(_characterData.Speed * Time.deltaTime * direction);
    }

    private void ChooseTarget()
    {
        targetToTrack = GetComponentInParent<TeamComposition>()?.GetMember();
    }
    public void ToTarget()
    {
        
        direction = targetToTrack.transform.position - transform.position;
        _isChoosing = true;
        StartCoroutine(WaitBeforeNewForce());
    }
}
