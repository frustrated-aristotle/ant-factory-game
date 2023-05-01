using UnityEngine;

public class PackageMovementHandler : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    public GameObject firstConveyor;
    private GameObject currentConveyor;
    private Vector3 targetPos;

    public int carriedAmount = 1;
    
    // Update is called once per frame
    private void Start()
    {
        targetPos = firstConveyor.GetComponent<ConveyorBelt>().targetPos;
    }

    private void FixedUpdate()
    {
        transform.position= Vector3.MoveTowards(transform.position, targetPos , Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != currentConveyor && col.CompareTag("Conveyor"))
        {
            NewTarget(col.gameObject);
        }
        else if(col.CompareTag("Buildings"))
        {
            col.GetComponent<Storage>().TakeInput(carriedAmount);
            Destroy(this.gameObject);
        }
    }
    
    public void NewTarget(GameObject newConveyor)
    {
        Vector3 newTargetPos = newConveyor.GetComponent<ConveyorBelt>().targetPos;
        currentConveyor = newConveyor;
        targetPos = newTargetPos;
    }
}
