using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Land", menuName = "Land")]
public class LandScriptableObject : ScriptableObject
{
    public string landName;
    
    public int cost;
    public int order;
    
    public bool isBought;
    
    public GameObject area;
    public GameObject ui;
    
    public SpriteRenderer[] rends;

    public Sprite mainSprite;
    
    public BoxCollider2D[] cols;

    public void ItsBought()
    {
        isBought = true;
        ui.GetComponent<Button>().interactable = false;
        AssignFertileTiles();
        ChangeAllTilesSprite();
        MakeAllTilesTouchable();
    }

    private void AssignFertileTiles()
    {
        FertileTileAssigner fertileTileAssigner = GameObject.FindObjectOfType<FertileTileAssigner>();
        fertileTileAssigner.AssignTilesAsFertile(area);
    }

    private void ChangeAllTilesSprite()
    {
        rends = area.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer rend in rends)
        {
            rend.sprite = mainSprite;
        }
    }

    private void MakeAllTilesTouchable()
    {
        cols = area.GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D col in cols)
        {
            col.enabled = true;
        }
    }
}
