using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public GameObject realHome, realDestination;
    [SerializeField]private GameObject temporaryHome, temporaryDestination;

    [SerializeField] float moveSpeed = 0.5f;
    private int index = 0;
    public  bool isNew;
    public List<Transform> realPath = new List<Transform>();
    private List<Transform> path = new List<Transform>();

    public Transform nextRoad;
    private void Start()
    {
        temporaryHome = realHome;
        temporaryDestination = realDestination;
        path = realPath;
    }
    private void Update()
    {
        MoveToNextConveyor();
    }

    private void MoveToNextConveyor()
    {
        transform.position= Vector3.MoveTowards(transform.position, nextRoad.position, Time.deltaTime * moveSpeed);

    }
    private void Move()
    {
        if (path[index].position == transform.position)
        {
            if (path[index].position == realDestination.transform.position)
            {
                ChangeTarget();
                isNew = false;
                index = 0;
            }
            else if (path[index].position == realHome.transform.position && isNew == false)
            {
                ChangeTarget();
                index = 0;
            }
            index++;
        }
        transform.position= Vector3.MoveTowards(transform.position, path[index].position, Time.deltaTime * moveSpeed);
    }

    public void ChangeTarget()
    {
        path.Reverse();
    }
}
