using UnityEngine;

public class SimpleIdleIA_2DTopDown : MonoBehaviour {

    Vector2 direction;
    public float maxTime, velocity;
    float actualTime, angle;

	void Update ()
    {
        Timmer();
        Idle();
    }

    void Idle()
    {
        if (actualTime == 0)
            direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        Vector3 newPos = direction * Time.deltaTime * velocity;
        this.gameObject.transform.position -= newPos;
    }

    void Timmer()
    {
        if (maxTime < actualTime)
            actualTime = 0;
        else
            actualTime += Time.deltaTime;
    }
}
