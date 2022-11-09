using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisManager : MonoBehaviour
{
    [SerializeField] StateManager _stateManager;
    GameObject _thisCurrentDebrisGroup;
    private void Start()
    {
        _thisCurrentDebrisGroup = _stateManager._currentActiveDebrisGroup;
        _thisCurrentDebrisGroup.SetActive(true);
    }
    private void OnEnable()
    {
        StateManager.OnStateChange.AddListener(SetDebris);
    }
    private void OnDisable()
    {
        StateManager.OnStateChange.RemoveListener(SetDebris);
    }
    private void SetDebris()
    {
        _thisCurrentDebrisGroup.SetActive(false);
        _thisCurrentDebrisGroup = _stateManager._currentActiveDebrisGroup;
        _thisCurrentDebrisGroup.SetActive(true);
    }
}
