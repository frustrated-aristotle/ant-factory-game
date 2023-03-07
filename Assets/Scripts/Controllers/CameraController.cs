using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]float panSpeed = 15f;
    [SerializeField]float scrollSpeed = 15f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Mathf.Lerp(panSpeed/3,panSpeed/2,panSpeed) * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Mathf.Lerp(panSpeed/3,panSpeed/2,panSpeed) * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left *Mathf.Lerp( panSpeed/3,panSpeed/2,panSpeed) * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Mathf.Lerp(panSpeed/3,panSpeed/2,panSpeed) * Time.deltaTime, Space.World);
        }

        float scrollValue = Input.GetAxis("Mouse ScrollWheel"); 
        Vector3 pos = transform.position;
        pos.z -= scrollValue * Mathf.Lerp(0,150,250) * scrollSpeed * Time.deltaTime;
        pos.z = Mathf.Clamp(pos.z, -100, -5);
//        if (pos.z < -5)
        {
            transform.position = pos; 
        }
    }
}
