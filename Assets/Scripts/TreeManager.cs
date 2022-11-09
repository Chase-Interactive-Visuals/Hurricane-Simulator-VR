using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    [SerializeField] StateManager _stateManager;
    GameObject _thisCurrentTreeGroup;

    private void Start()
    {
        _thisCurrentTreeGroup = _stateManager._currentActiveTreeGroup;
        _thisCurrentTreeGroup.SetActive(true);
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
        _thisCurrentTreeGroup.SetActive(false);
        _thisCurrentTreeGroup = _stateManager._currentActiveTreeGroup;
        _thisCurrentTreeGroup.SetActive(true);
    }
}
