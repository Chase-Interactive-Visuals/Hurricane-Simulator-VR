using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] StateManager _stateManager;

    [SerializeField] GameObject _userPhone;
    private void OnEnable()
    {
        StateManager.OnStateChange.AddListener(DoSomething);
    }
    private void OnDisable()
    {
        StateManager.OnStateChange.RemoveListener(DoSomething);
    }
    private void DoSomething()
    {
        //_windZone.
    }

}
