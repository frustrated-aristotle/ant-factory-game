using System;
using Unity.Mathematics;
using UnityEngine;

public class PlaceHolderManager : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private GameStateSO state;
    private void Start()
    {
        cam = GameObject.Find("Camera").GetComponent<Camera>();
    }

    void Update()
    {
        if (state.IsTheStatePurchase())
        {
            SendRay();
        }
    }

   
    private void SendRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if(hit.transform.gameObject.CompareTag("Connectable")) 
        {
            ShowPlaceHolder(hit);        
        }
    }

    private void ShowPlaceHolder(RaycastHit2D hit)
    {
        Debug.Log(state.currentConveyorIndex);
        hit.transform.GetComponent<SpriteRenderer>().sprite = state.GetSprite();
    }
}
