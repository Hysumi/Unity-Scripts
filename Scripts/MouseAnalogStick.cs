using UnityEngine;

public class MouseAnalogStick : MonoBehaviour {

    bool isDragging;
    Vector2 dragOrigin;

    Vector2 AnalogStick()
    {
        if (isDragging)
        {
            Vector2 dragVector;
            Vector2 mousePosClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            dragVector = dragOrigin - mousePosClick;

            Debug.DrawLine(dragOrigin, mousePosClick, Color.black);

            if (Input.GetMouseButtonUp(0))
                isDragging = false;
            return (dragVector);
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                dragOrigin = ray.origin;
            }
        }
        return (Vector2.zero);
    }
}
