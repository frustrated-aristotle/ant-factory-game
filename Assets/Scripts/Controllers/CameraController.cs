using System;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]float panSpeed = 15f;
    [SerializeField]float scrollSpeed = 15f;
    private Vector3 refMouse;
    public float speed = 5f;
    public float smoothTime = 0.3f;

    private float currentTime = 0f;

    private bool refPosTaken=false;
    // Update is called once per frame
    void Update()
    {
        MoveWithKeybord();
        MoveWithScroolWheel();
        DragAndDropMouse();
    }
    
    private void DragAndDropMouse()
    {
        

        if (Input.GetMouseButton(2))
        {
            if (!refPosTaken)
            {
                refMouse = Input.mousePosition;
                refPosTaken = true;
            }
            Vector3 mousePos = Input.mousePosition;
            bool x = MakeBool(mousePos.x, refMouse.x); 
            bool y = MakeBool(mousePos.y, refMouse.y); 
            bool z = MakeBool(mousePos.z, refMouse.z); 
            if (x && y && z)
            {
                MoveWithMidButton(refMouse,mousePos);
                refPosTaken = false;
            }
        }
    }

    private bool MakeBool(float mouseCoordinate, float refCoordinate)
    {
        return (mouseCoordinate - refCoordinate > 2f || mouseCoordinate - refCoordinate <= 2f) &&
               mouseCoordinate != refCoordinate;
    }

    private void MoveWithMidButton(Vector3 refMouse, Vector3 mouseMovePos)
    {
        currentTime += Time.deltaTime;
        float t = Mathf.SmoothStep(0f, 1f, Mathf.Clamp01(currentTime / smoothTime));
        Vector3 direction = (mouseMovePos - refMouse).normalized;
        float currentSpeed = Mathf.Lerp(0f, speed, t);
        transform.Translate(direction * currentSpeed * Time.deltaTime * -5f);
        /*
        Vector3 camPos = mouseMovePos - refMouse;
        Debug.Log("Translate pos : "  + -camPos);
        Mathf.Lerp( refMouse,mouseMovePos, 0.5f);
        transform.Translate(-camPos.normalized * 0.7f);
        */
    }

    private void MoveWithScroolWheel()
    {
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.z -= scrollValue * Mathf.Lerp(0, 150, 250) * scrollSpeed * Time.deltaTime;
        pos.z = Mathf.Clamp(pos.z, -100, -5);
//        if (pos.z < -5)
        {
            transform.position = pos;
        }
    }

    
    private void MoveWithKeybord()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Mathf.Lerp(panSpeed / 3, panSpeed / 2, panSpeed) * Time.deltaTime,
                Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Mathf.Lerp(panSpeed / 3, panSpeed / 2, panSpeed) * Time.deltaTime,
                Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Mathf.Lerp(panSpeed / 3, panSpeed / 2, panSpeed) * Time.deltaTime,
                Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Mathf.Lerp(panSpeed / 3, panSpeed / 2, panSpeed) * Time.deltaTime,
                Space.World);
        }
    }
}
