using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class SpriteAssigner : MonoBehaviour
{
    public Sprite mainSprite, bought;
    public SpriteRenderer[] renderers;
    public BoxCollider2D[] cols;
    [ContextMenu("AssignTheSprite")]
    public void AssignTheSprite(GameObject button)
    {
        button.GetComponent<Button>().interactable = false;
        renderers = transform.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer rend in renderers)
        {
            rend.sprite = bought;
        }
        TurnOnOffCol();
        FindNewTilesNeighbours();
        FertileTileAssigner fertileTileAssigner = GameObject.FindObjectOfType<FertileTileAssigner>();
        fertileTileAssigner.AssignTilesAsFertile(this.gameObject);
    }

    private void FindNewTilesNeighbours()
    {
        foreach (NeighbourFinder neighbourFinder in transform.GetComponentsInChildren<NeighbourFinder>())
        {
            neighbourFinder.neighbours.Clear();
            neighbourFinder.FindNeighbours();
            Debug.Log("n finder");
        }
    }

    [ContextMenu("TurnOnOffCol")]
    private void TurnOnOffCol()
    {
        cols = GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D col in cols)
        {
            bool isEnabled = col.enabled;
            col.enabled = !isEnabled;
        }
    }
}
