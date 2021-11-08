using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ImpactReceiver : MonoBehaviour
{
    float mass = 3.0F;
    Vector3 impact = Vector3.zero;
    private CharacterController character;
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (impact.magnitude > 0.2F) character.Move(impact * Time.deltaTime);
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }
    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        impact += dir.normalized * force / mass;
    }

    //Code from:
    //Needed help doing this without rigidbody. This is for the walljump mechanic.
    //https://answers.unity.com/questions/242648/force-on-character-controller-knockback.html
}