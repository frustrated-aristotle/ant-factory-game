using UnityEngine;

public class PackageMovementHandler : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    public GameObject firstConveyor;
    private GameObject currentConveyor;
    private Vector3 targetPos;
    
    // Update is called once per frame
    private void Start()
    {
        targetPos = firstConveyor.transform.position;
    }

    private void FixedUpdate()
    {
        transform.position= Vector3.MoveTowards(transform.position, targetPos , Time.deltaTime * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject != currentConveyor)
        {
            NewTarget(col.gameObject);
        }
    }

    public void NewTarget(GameObject newConveyor)
    {
        Vector3 newTargetPos = newConveyor.transform.position;
        currentConveyor = newConveyor;
        targetPos = newTargetPos;
    }
}
