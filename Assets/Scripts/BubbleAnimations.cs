using UnityEngine;

public class BubbleAnimations : MonoBehaviour
{
    private Animator _animator;
    private BubbleMovement _movement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void UnpauseBubble()
    {
        _movement.StartMove();
    }

    public void TriggerStartAnim()
    {
        _animator.ResetTrigger("Start");
        _animator.SetTrigger("Start");
    }

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<BubbleMovement>();
        TriggerStartAnim();
    }
}
