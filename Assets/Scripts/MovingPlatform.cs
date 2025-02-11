using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] points;

    private void Start()
    {
        DOTween.Sequence()
            .Append(transform.DOMoveX(points[1].position.x, 2f).SetEase(Ease.Linear))
            .Append(transform.DOMoveX(points[0].position.x, 2f).SetEase(Ease.Linear))
            .SetLoops(-1, LoopType.Yoyo)
            .Play();
    }
}
