using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    [SerializeField] StateManager _stateManager;
    [SerializeField] WindZone _windZone;
    [SerializeField] TSP_WindController _windController;

    private void OnEnable()
    {
        StateManager.OnStateChange.AddListener(SetWind);
    }
    private void OnDisable()
    {
        StateManager.OnStateChange.RemoveListener(SetWind);
    }
    private void SetWind()
    {
        _windZone.windMain = _stateManager._currentWindZoneMain;
        _windZone.windTurbulence = _stateManager._currentWindZoneTurbulence;
        _windZone.windPulseMagnitude = _stateManager._currentWindZonePulseMagnitude;
        _windZone.windPulseFrequency = _stateManager._currentWindZonePulseFrequencye;
        _windController.speed = _stateManager._currentWindManagerSpeed;
        _windController.worldFrequency = _stateManager._currentWindManagerWorldFrequency;
        _windController.bendAmount = _stateManager._currentWindManagerBendAmount;
    }
}
