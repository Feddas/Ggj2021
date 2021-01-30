using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ItemDrop : MonoBehaviour
{
    public float SpawnForce = 10;
    public Vector2 SpawnDirection = new Vector2(-1, -1);

    public Collider2D ActivateOnStopped;

    private Rigidbody2D myRigidbody
    {
        get
        {
            if (_rigidbody == null)
            {
                _rigidbody = this.GetComponent<Rigidbody2D>();
            }
            return _rigidbody;
        }
    }
    private Rigidbody2D _rigidbody;

    // void Start() { }
    // void Update() { }

    void OnEnable()
    {
        myRigidbody.AddForce(SpawnDirection * SpawnForce);

        StartCoroutine(waitUntilStopped());
    }

    IEnumerator waitUntilStopped()
    {
        yield return new WaitForSeconds(0.5f); // give some time for the drop to start moving
        yield return new WaitUntil(() => myRigidbody.velocity.magnitude <= float.Epsilon);

        ActivateOnStopped.enabled = true;
    }
}
