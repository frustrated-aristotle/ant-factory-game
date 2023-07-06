using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoUIManager : MonoBehaviour
{
    private int stringIndex = 0;
    [SerializeField] private GameObject buttonPrev, buttonNext;
    public int StringIndex
    {
        get => stringIndex;
        
        set
        {
            Debug.Log("a");
            stringIndex+= value;
            HandleButtons();
            textInfoContent.text = infoStrings[StringIndex];
        }
    }

    private void HandleButtons()
    {
        if (StringIndex == 0)
        {
            buttonPrev.SetActive(false);
        }
        else if (StringIndex == infoStrings.Count - 1)
        {
            buttonNext.SetActive(false);
        }
        else
        {
            buttonPrev.SetActive(true);
            buttonNext.SetActive(true);
        }
    }

    private List<string> infoStrings = new List<string>();

    [SerializeField] private TextMeshProUGUI textInfoContent;

    private void Start()
    {
        infoStrings.Add("This is your ant factory. Capitalism exist in this game. This means, you need to gain money to survive. To earn money, you will buy extractors, processors and exporters.");
        infoStrings.Add("Production chain in this game is quite basic. The production chain in this game is quite basic. You will extract water and transport it to wheat farms. The farms will process the water and produce wheat to sell to exporters.");
        infoStrings.Add("Once you press \"b\", buildings menu will open. You can buy any of these buildings if you have enough money and a suitable place to settle them. All buildings, except conveyors, can only be placed on fertile areas.");
        infoStrings.Add("It is extremely obvious that more colorful tiles represent fertile tiles. \nOnce you place a building or a conveyor belt on a fertile tile and then bulldoze it, the prior fertile tile will transform into an empty tile.");
        infoStrings.Add("You can not rotate buildings.\nThey will receive their inputs from up, right and down but deliver their outputs to the conveyors on the left side.\nIf your building does not have any adjacent conveyor, it will cause problem.");
        infoStrings.Add("\"Water\" will extract water from a fertile tile. It does not need any input goods. It will start to deliver water packages if it has an adjacent conveyor on its left side.");
        infoStrings.Add("\"Wheat\" refers to the Wheat Farm. They will receive water packages, process the water, and create wheat packages. Since they are buildings, they require adjacent conveyors on their left side to deliver the created packages.");
        infoStrings.Add("The Exporter is the place where you export your wheat packages to your customers. They receives wheat packages and delivers them to your customers. The Exporter does not require any output conveyor. Instead, they only receive packages.");
        infoStrings.Add("You will earn money when you complete a contract. Each contract has its own requirements, such as ordered goods, delivery time, expected gain, and loss cost. If you cannot deliver the expected goods of your contract to an exporter, your money will decrease as a loss cost.");
        infoStrings.Add("After you press \"l\", loan menu will appear. You can take out a loan when you want to invest in your factory. More production chains mean more money, but you need to be very careful about repaying your debt.");
        infoStrings.Add("What you are currently seeing is an open area. There are three more areas in this game where you can expand your factory. You can open Lands menu by pressing \"z\" key. The second area is on the left, the fourth area is below, and the remaining one is the third area.");
        textInfoContent.text = infoStrings[0];
    }

    public void NextButton()
    {
        StringIndex = +1;
    }

    public void PreviousButton()
    {
        StringIndex = -1;
    }

}




/*
 DONE
   This is your ant factory.Capitalism exist in this game. This means, you need to gain money to live. To gain money, you will buy exractors, processors and exporters.

---
DONE
Production chain in this game is quite basic. you will extract water and transport water to wheat farms. those farms will process water and create wheats to sell in exporter.

---
DONE
Once you press "b", buildings menu will open. You can buy any of these buildings if you have enough money and suitable place to settle it. All buildings, except conveyors, can only be placed onto fertile areas.

--
DONE
It is extremely obvious that more colorful tiles are fertile tiles. \nOnce you place a building or a conveyor belt onto a fertile tile and then bulldoze it, prior fertile tile will transform into an empty tile.

---
DONE
You can not rotate buildings.\nThey will receive their inputs from up, right and down but deliver their outputs to the left side conveyors.\nIf your building does not have any adjacent conveyor, it will cause problem.

---
DONE
\"Water\" will extract water from a fertile tile. It does not need any input goods. It will start to deliver water packages if it has an adjacent conveyor on its left side.

----
DONE
\"Wheat\" is the Wheat Farm, They will get water package, process water and create wheat packages. since they are buildings, they need adjacent conveyors at their left side to deliver created packages.

---
DONE
Exporter is the place where you are exporting your wheat packages to your customers. they will receive wheat packages and deliver them to your customer. They does not require any output conveyor. Instead, they only recieve packages.

-------
DONE
You will gain money when you complete a contract. Each contract has its own demands: ordered goods, deliver time, expected gain and loss cost. If you can not delivered expected goods of your contract to an exporter, your money will decrease as loss cost.

---

DONE
After you press \"l\", loan menu will appear. you can get a loan when you want to invest on your factory. more production chains means more money. But you need to be very careful about paying your debt. 
---

What you currently are seeing is an opened area. There are 3 more areas in this game to grow your factory. You can open Lands menu by pressing \"z\" key. Second are is on the left, Fourth is on the down and the other one is third area.
 */