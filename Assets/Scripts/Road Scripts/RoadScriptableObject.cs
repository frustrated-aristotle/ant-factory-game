using UnityEngine;

[CreateAssetMenu(fileName = "Road", menuName = "Roads")]
public class RoadScriptableObject : ScriptableObject
{
    public GameObject currentRoad, mainRoad, secondRoad;
    public GameObject vertical, horizontal, rightBottom, leftBottom, thirdBottom, thirdUp, thirdRight, thirdLeft, rightUp, leftUp, fourWays;
    
    public void MakeTheRoadVertical()
    {
        currentRoad = vertical;
    }

    public void MakeTheRoadHorizontal()
    {
        currentRoad = horizontal;
        
    }
    public void MakeTheRoadRightBottom()
    {
        currentRoad = rightBottom;
    }
    public void MakeTheRoadLeftBottom()
    {
        currentRoad = leftBottom;

    }
    public void MakeTheRoadThirdBottom()
    {
        currentRoad = thirdBottom;

    }
    public void MakeTheRoadThirdUp()
    {
        currentRoad = thirdUp;
    }

    public void MakeTheRoadThirdRight()
    {
        currentRoad = thirdRight;
    }

    public void MakeTheRoadThirdLeft()
    {
        currentRoad = thirdLeft;
    }
    public void MakeTheRoadLeftUp()
    {
        currentRoad = leftUp;
    }
    
    public void MakeTheRoadRigthUp()
    {
        currentRoad = rightUp;
    }
    public void MakeTheRoadFourWays()
    {
        currentRoad = fourWays;
    }
    
    public void ChangeRoad()
    {
        if (currentRoad == mainRoad)
            currentRoad = secondRoad;
        else if (currentRoad == secondRoad)
            currentRoad = mainRoad;
    }
}
