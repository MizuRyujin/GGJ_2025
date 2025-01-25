using UnityEngine;
using System.Collections;
using System;

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
        float startY = _position.y;
        
        while (timer < maxDuration)
        {

            yield return null;
        }
    }
}
