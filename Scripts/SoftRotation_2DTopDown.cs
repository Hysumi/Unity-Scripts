using UnityEngine;

public class SoftRotation_2DTopDown : MonoBehaviour {

    public void SoftRotation(Vector2 direction, float rotationSpeed, GameObject g)
    {
        float ang = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        ang += 90;

        if (ang < 0)
            ang += 360;

        float actualAngle = g.transform.localEulerAngles.z;
        float difAngle = ang - actualAngle;

        if (difAngle >= 0)
        {
            if (Mathf.Abs(difAngle) < 180)
                RotationAnticlockwise(actualAngle, rotationSpeed, g);
            else
                RotationClockwise(actualAngle, rotationSpeed, g);
        }
        else
        {
            if (Mathf.Abs(difAngle) > 180)
                RotationAnticlockwise(actualAngle, rotationSpeed, g);
            else
                RotationClockwise(actualAngle, rotationSpeed, g);
        }
    }

    void RotationClockwise(float actual, float rotationSpeed, GameObject g)
    {
        g.transform.localEulerAngles =
            new Vector3(0, 0, actual - rotationSpeed * Time.deltaTime);
    }

    void RotationAnticlockwise(float actual, float rotationSpeed, GameObject g)
    {
        g.transform.localEulerAngles =
            new Vector3(0, 0, actual + rotationSpeed * Time.deltaTime);
    }

}
