using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    [SerializeField] private float _bounceStrenght = 100f;
    [SerializeField] private float _bubbleStrenghtRefill = 20f;
    private Animator _animator;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other)
    {
        other.collider.attachedRigidbody.AddForce(0, _bounceStrenght, 0);
        other.collider.GetComponent<BubbleState>().BubbleStrenght += _bubbleStrenghtRefill;
        if (other.collider.GetComponent<BubbleState>().BubbleStrenght > 100f)
        {
            other.collider.GetComponent<BubbleState>().BubbleStrenght = 100f;
        }
        _animator.SetTrigger("Bounce");
    }
}
