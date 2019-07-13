using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animation _mainMenuAnimator;
    [SerializeField] private AnimationClip _fadeOutAnimation;
    [SerializeField] private AnimationClip _fadeInAnimation;
    
    public void OnFadeOutComplete()
    {
        Debug.LogWarning("FadeOut Complete");
    }

    public void OnFadeInComplete()
    {
        Debug.LogWarning("FadeIn Complete");
        UIManger.Instance.SetDummyCameraActive(true);
    }

    public void FadeOut()
    {
        UIManger.Instance.SetDummyCameraActive(false);

        _mainMenuAnimator.Stop();
        _mainMenuAnimator.clip = _fadeOutAnimation;
        _mainMenuAnimator.Play();
    }

    public void FadeIn()
    {
        _mainMenuAnimator.Stop();
        _mainMenuAnimator.clip = _fadeInAnimation;
        _mainMenuAnimator.Play();
    }
}
