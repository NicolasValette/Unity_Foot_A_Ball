using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : Ball
{
    private bool _isChoosing = false;
    private bool _newTargetAvailable;
    private Vector3 direction;
    private GameObject targetToTrack = null;
   // private Dictionary<PlayerData.Behavior, Action> _moveMethod = new Dictionary<PlayerData.Behavior, Action>();
    private Action[] _moveMethod ;
    void Start()
    {
        _moveMethod = new Action[4];
        _moveMethod[(int)PlayerData.Behavior.Random] = RandomMove;
        _moveMethod[(int)PlayerData.Behavior.ToPlayer] = ToPlayer;
        _moveMethod[(int)PlayerData.Behavior.ToTarget] = ToTarget;
        InitJersey();
        _newTargetAvailable = true;
    }

    private void OnEnable()
    {
        TeamMember.PlayerDead += WaitBeforeChoosingTarget;
    }
    private void OnDisable()
    {
        TeamMember.PlayerDead -= WaitBeforeChoosingTarget;
    }
    // Update is called once per frame
    void Update()
    {
        _moveMethod[(int)_characterData.PlayerBehavior]();
    }
    public IEnumerator WaitBeforeDoingSomething(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }

    #region Random Behavior
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
            StartCoroutine(WaitBeforeDoingSomething(_characterData.WaitingTimeBetweenForce, () => _isChoosing = false)) ;
        } 
        _rigidbody.AddForce(_characterData.Speed * Time.deltaTime * direction);
    }
    #endregion
    #region To Player Behavior
    public void ToPlayer()
    {
        Debug.Log("ToPlayer");
        if (!_isChoosing)
        {
            direction = MatchManager.Player.transform.position - transform.position;
            direction.Normalize();
           // Debug.Log(direction);
            
            _isChoosing = true;
            StartCoroutine(WaitBeforeDoingSomething(_characterData.WaitingTimeBetweenForce, () => _isChoosing = false));
        }
        _rigidbody.AddForce(_characterData.Speed * Time.deltaTime * direction);
    }
    #endregion
    #region To Target Behavior

    public void WaitBeforeChoosingTarget()
    {
        Debug.Log("WaitBeforeChoosingTarget");
        targetToTrack = null;
        StartCoroutine(WaitBeforeDoingSomething(_characterData.WaitingTimeBetweenForce, () => _newTargetAvailable = true));
    }
    private void ChooseTarget()
    {
       
            Debug.Log("ChooseTarget");
            targetToTrack = GetComponentInParent<TeamComposition>()?.GetMember();
            if (targetToTrack != null)
            {
                targetToTrack.GetComponent<TeamMember>().IsTargeted = true;
            }   
    }
    public void ToTarget()
    {
        Debug.Log("ToTarget : " + _newTargetAvailable);

        if (targetToTrack == null && _newTargetAvailable)
        {
            _newTargetAvailable = false;
            ChooseTarget();
            direction = targetToTrack.transform.position - transform.position;
        }
        _rigidbody.AddForce(_characterData.Speed * Time.deltaTime * direction);
    }
    #endregion
}
