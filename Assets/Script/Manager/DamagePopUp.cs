using System;
using TMPro;
using UnityEngine;

public class DamagePopUp : MonoBehaviour
{
    public Vector2 InitialVelocity; 
    public float lifetime = 1.5f;

    // Reference to components
    [NonSerialized] public Rigidbody2D rb; 
    private TextMeshPro damageTMP; 

    private void Start()
    {
        // Get component's attached to this GameObject
        damageTMP = GetComponent<TextMeshPro>();
        rb = GetComponent<Rigidbody2D>();

        // Set the initial velocity of the Rigidbody2D component
        rb.linearVelocity = InitialVelocity;
        Destroy(gameObject, lifetime); // Destroy the pop-up after its lifetime
    }
}
