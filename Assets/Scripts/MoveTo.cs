using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public Transform FinalPosition = null;
    public float MoveInSeconds = 2;

    // void Start() { }
    // void Update() { }

    public void StartMove()
    {
        StartCoroutine(move());
    }

    private IEnumerator move()
    {
        Vector3 startPos = this.transform.position;
        Quaternion startRot = this.transform.rotation;
        Vector3 startScale = this.transform.localScale;

        float moveTime = 0;
        while (moveTime < MoveInSeconds)
        {
            moveTime += Time.deltaTime;
            float percent = moveTime / MoveInSeconds;

            this.transform.position = Vector2.Lerp(startPos, FinalPosition.position, percent);
            this.transform.rotation = Quaternion.Lerp(startRot, FinalPosition.rotation, percent);
            this.transform.localScale = Vector2.Lerp(startScale, FinalPosition.localScale, percent);
            yield return null;
        }
    }
}
