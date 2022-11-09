using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    [SerializeField] StateManager _stateManager;

    GameObject _thisCurrentWaterObject;

    private void Start()
    {
        _thisCurrentWaterObject = _stateManager._currentActiveWaterObject;
        _thisCurrentWaterObject.SetActive(true);
    }
    private void OnEnable()
    {
        StateManager.OnStateChange.AddListener(SetWaterObject);
    }
    private void OnDisable()
    {
        StateManager.OnStateChange.RemoveListener(SetWaterObject);
    }
    private void SetWaterObject()
    {
        _thisCurrentWaterObject.SetActive(false);
        _thisCurrentWaterObject = _stateManager._currentActiveWaterObject;
        _thisCurrentWaterObject.SetActive(true);
    }
}
