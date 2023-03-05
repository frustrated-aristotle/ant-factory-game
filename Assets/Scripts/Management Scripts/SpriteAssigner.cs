using UnityEngine;

public class SpriteAssigner : MonoBehaviour
{
    public Sprite sprite;
    public SpriteRenderer[] renderers;
    public BoxCollider2D[] cols;
    [ContextMenu("AssignTheSprite")]
    private void AssignTheSprite()
    {
        Debug.Log("A");
        renderers = transform.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer rend in renderers)
        {
            rend.sprite = sprite;
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
