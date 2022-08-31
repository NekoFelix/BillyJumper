using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlatformSegment : MonoBehaviour
{
    public void Bounce(float force, Vector3 center, float radius)
    {
        if (TryGetComponent(out Rigidbody rb))
        {
            rb.isKinematic = false;
            rb.AddExplosionForce(force, center, radius);
        }
    }
}
