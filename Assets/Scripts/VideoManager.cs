using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] StateManager _stateManager;

    [HideInInspector]
    public VideoClip _currentPhoneVideoClip;

    [HideInInspector]
    public VideoClip _currentTelevisionVideoClip;

    [Header("Phone Videos")]
    [SerializeField] VideoClip _phoneVideo1;

    [Header("Television Videos")]
    [SerializeField] VideoClip _televisionVideo1;

    private void OnEnable()
    {
        StateManager.OnStateChange.AddListener(VideoSelectionLogic);
    }
    private void OnDisable()
    {
        StateManager.OnStateChange.RemoveListener(VideoSelectionLogic);
    }
    private void VideoSelectionLogic()
    {
        //logic to set current phone and tv video clips
        _currentPhoneVideoClip = _phoneVideo1;
        _currentTelevisionVideoClip = _televisionVideo1;
    }

    public void SetCurrentPhoneVideoClipInState()
    {
        _stateManager._currentPhoneVideoClip = _currentPhoneVideoClip;
    }
    public void SetCurrentTelevisionVideoClipInState()
    {
        _stateManager._currentTelevisionVideoClip = _currentTelevisionVideoClip;
    }
}
