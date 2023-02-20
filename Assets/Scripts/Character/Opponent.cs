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
    private Action[] _moveMethod;
    void Start()
    {
        _moveMethod = new Action[4];
        _moveMethod[(int)PlayerData.Behavior.Random] = RandomMove;
        _moveMethod[(int)PlayerData.Behavior.ToPlayer] = ToPlayer;
        _moveMethod[(int)PlayerData.Behavior.ToTarget] = ToTarget;
        _characterData = MatchManager.OppenentData;
        InitJersey();
        WaitBeforeChoosingTarget();
        
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
    void FixedUpdate()
    {
        _moveMethod[(int)_characterData.PlayerBehavior]();

        Debug.DrawLine(transform.position, direction, Color.red);
    }
    public IEnumerator WaitBeforeDoingSomething(float delay, Action action)
    {
        Debug.Log("###WaitBeforeDoing, delay : " + delay + "Time : " + Time.time + "New target : " + _newTargetAvailable);
        yield return new WaitForSeconds(delay);
        action();
        Debug.Log("###END WaitBeforeDoing, delay : " + delay + "Time : " + Time.time + "New target : " + _newTargetAvailable);
    }

    #region Random Behavior
    public void RandomMove()
    {  
        if (!_isChoosing)
        {
            Debug.Log("RandomMove");
            Vector3 dir = UnityEngine.Random.onUnitSphere;
            direction = new Vector3 (dir.x, 0f, dir.z) ;
            direction.Normalize();
            Debug.Log(direction);
            _isChoosing = true;
            StartCoroutine(WaitBeforeDoingSomething(_characterData.WaitingTimeBetweenForce, () => _isChoosing = false));
      
        _rigidbody.AddForce(_characterData.Speed * Time.fixedDeltaTime * direction, ForceMode.Impulse);
        }
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
           
        _rigidbody.AddForce(_characterData.Speed * Time.fixedDeltaTime * direction, ForceMode.Impulse);
        }
       
    }
    #endregion
    #region To Target Behavior

    public void WaitBeforeChoosingTarget()
    {
        Debug.Log("WaitBeforeChoosingTarget");
        targetToTrack = null;
        StartCoroutine(WaitBeforeDoingSomething(_characterData.WaitingTimeBetweenTarget, () => _newTargetAvailable = true));
    }
    private void ChooseTarget()
    {
        Debug.Log("ChooseTarget");
        targetToTrack = MatchManager.PlayerTeamComposition.GetComponent<TeamComposition>()?.GetMember();
        if (targetToTrack != null)
        {
            Debug.Log("New Target name : " + targetToTrack.name);
            targetToTrack.GetComponent<TeamMember>().IsTargeted = true;
        }
    }
    public void ToTarget()
    {
       
        if (targetToTrack == null && _newTargetAvailable)
        { 
            Debug.Log("ToTarget : " + _newTargetAvailable);
            _newTargetAvailable = false;
            ChooseTarget();
            
        }
        
        if (targetToTrack != null)
        {
            direction = targetToTrack.transform.position - transform.position;
            _rigidbody.AddForce(_characterData.Speed * Time.fixedDeltaTime * direction, ForceMode.Impulse);
        }   
    }
    #endregion
}
