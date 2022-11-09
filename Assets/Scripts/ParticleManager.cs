using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] StateManager _stateManager;
    GameObject _thisCurrentParticleGroup;

    private void Start()
    {
        _thisCurrentParticleGroup = _stateManager._currentActiveParticleGroup;
        _thisCurrentParticleGroup.SetActive(true);
    }
    private void OnEnable()
    {
        StateManager.OnStateChange.AddListener(SetTrees);
    }
    private void OnDisable()
    {
        StateManager.OnStateChange.RemoveListener(SetTrees);
    }
    private void SetTrees()
    {
        _thisCurrentParticleGroup.SetActive(false);
        _thisCurrentParticleGroup = _stateManager._currentActiveTreeGroup;
        _thisCurrentParticleGroup.SetActive(true);
    }
}
