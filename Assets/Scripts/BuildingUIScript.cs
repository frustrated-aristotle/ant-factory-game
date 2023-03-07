using System;
using UnityEngine;

public class BuildingUIScript : MonoBehaviour
{
    private float x1 = 684;
    private float x2 = 1235;
    private float y1 = 200;
    private float y2 = 375;

    private void Update()
    {
        if (CanMouseClick())
        {
            Debug.Log("Inside: " + Input.mousePosition);
        }
        else
        {
            Debug.Log("Not inside: "  + Input.mousePosition);
        }

    }

    /// <summary>
    /// This method checks if the mouse is outside of the building menu's boundaries.
    /// To prevent placing buildings when the mouse is on building menu, we'll use this checker.
    /// </summary>
    /// <returns></returns>
    public bool CanMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        bool isInsideX = mouseX < x2 && mouseX > x1;
        bool isInsideY = mouseY < y2 && mouseY > y1;
        if (isInsideX && isInsideY)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
