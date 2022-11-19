using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableDetailController : MonoBehaviour
{
    UIManager _uiManager;

    [SerializeField] public string _interactableName;

    [TextArea(minLines: 2, maxLines: 4)]
    [SerializeField] public string _interactableDetails;
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField] public TextMeshProUGUI _interactableDetailText;

    private void Start()
    {
        _canvasGroup.alpha = 0.0f;
    }

    public void ShowHideUIMenu()
    {
        if (_canvasGroup.alpha > .5f)
        {
            StartCoroutine(UIMenuFade(1, 0, .15f, _canvasGroup));
        }
        else
        {
            StartCoroutine(UIMenuFade(0, 1, .15f, _canvasGroup));
        }
    }
    private IEnumerator UIMenuFade(int start, int end, float duration, CanvasGroup uiMenu)
    {
        float t = 0f;
        while (t < duration)
        {
            uiMenu.alpha = Mathf.Lerp(start, end, t / duration);
            t += Time.deltaTime;
            if (t > duration * .97)
            {
                t = duration;
                uiMenu.alpha = end;
            }
            yield return null;
        }
    }
}
