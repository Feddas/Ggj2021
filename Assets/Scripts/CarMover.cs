using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;

    public Vector2 MinMaxY = new Vector2(-10, 20);

    public string GarageScene = "2Room";

    public UnityEngine.Events.UnityEvent AtTop = null;

    private Vector3 position = Vector3.zero;
    private bool firstTop = true;

    void Start()
    {
        position = this.transform.position;
    }

    void Update()
    {
        if (Input.GetKey(Up) && position.y < MinMaxY.y)
        {
            moveVerticallyBy(Time.deltaTime);
        }
        else if (Input.GetKey(Down) && position.y > MinMaxY.x)
        {
            moveVerticallyBy(-1 * Time.deltaTime);
        }

        if (position.y >= MinMaxY.y && firstTop)
        {
            firstTop = false;
            if (AtTop != null)
            {
                AtTop.Invoke();
            }
        }
    }

    public void GoToGarageIn(float seconds)
    {
        StartCoroutine(goToGarageIn(seconds));
    }

    private IEnumerator goToGarageIn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        UnityEngine.SceneManagement.SceneManager.LoadScene(GarageScene);
    }

    void moveVerticallyBy(float y)
    {
        position.y += y;

        this.transform.position = position;
    }
}
