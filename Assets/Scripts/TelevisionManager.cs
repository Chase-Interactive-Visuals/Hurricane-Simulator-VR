using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TelevisionManager : MonoBehaviour
{
    [SerializeField] StateManager _stateManager;

    [SerializeField] VideoPlayer _televisionVideoPlayer;

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
        SetTelevisionCurrentVideoDisplayed();
    }

    void SetTelevisionCurrentVideoDisplayed()
    {
        _televisionVideoPlayer.clip = _stateManager._currentTelevisionVideoClip;
    }
}
