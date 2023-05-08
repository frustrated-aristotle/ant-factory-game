using UnityEngine;
using static GameStateManager.States;

public class PlaceHolderManager : MonoBehaviour
{
    private Camera cam;
    [SerializeField]

    private GameStateManager stateManager;
    private void Start()
    {
        stateManager = GameObject.FindObjectOfType<GameStateManager>();
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        
    }

    void Update()
    {
        if (stateManager.AreStatesTheSame(PURCHASE))
        {
            SendRay();
        }
    }

   
    private void SendRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit && hit.transform.gameObject.CompareTag("Connectable"))
        {
            ShowPlaceHolder(hit);        
        }
    }

    private void ShowPlaceHolder(RaycastHit2D hit)
    {
        hit.transform.GetComponent<SpriteRenderer>().sprite = stateManager.GetSprite();
    }
}
