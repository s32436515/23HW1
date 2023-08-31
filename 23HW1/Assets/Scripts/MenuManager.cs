using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject frog;

    void Start()
    {
        LeanTween.moveY(frog, 365, 1f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(frogMoveA);
    }

    void frogMoveA() => LeanTween.moveY(frog, 305, 1f).setEase(LeanTweenType.easeOutCubic).setOnComplete(frogMoveB);
    void frogMoveB() => LeanTween.moveY(frog, 365, 1f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(frogMoveA);
}
