using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    public string VerticalAxis = "Vertical";

    public Vector2 MinMaxY = new Vector2(-10, 20);

    public UnityEngine.Events.UnityEvent AtTop = null;

    private Vector3 position = Vector3.zero;
    private bool firstTop = true;

    void Start()
    {
        position = this.transform.position;
    }

    void Update()
    {
        var delta = Input.GetAxisRaw(VerticalAxis);

        // check if has input and this object is within bounds
        if (delta == 0)
            return;

        // move vertically
        if (delta > 0 && position.y < MinMaxY.y)
        {
            moveVerticallyBy(delta * Time.deltaTime);
        }
        else if (delta < 0 && position.y > MinMaxY.x)
        {
            moveVerticallyBy(delta * Time.deltaTime);
        }

        // Fire event if first time at top
        if (position.y >= MinMaxY.y && firstTop)
        {
            firstTop = false;
            if (AtTop != null)
            {
                AtTop.Invoke();
            }
        }
    }

    void moveVerticallyBy(float y)
    {
        position.y += y;

        this.transform.position = position;
    }
}
