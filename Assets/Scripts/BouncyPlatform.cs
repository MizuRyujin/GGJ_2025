using UnityEngine;
using System.Collections;

public class BouncyPlatform : MonoBehaviour
{
    [SerializeField] private float _bounceStrenght;
    private Vector3 _position;

    private void OnCollisionEnter(Collision other)
    {
        other.collider.attachedRigidbody.AddForce(0, _bounceStrenght, 0);
    }

    private IEnumerator Bounce(float timer, int maxDuration)
    {
        while (timer < maxDuration)
        {

            yield return null;
        }
    }
}
