using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using Unity.VisualScripting;

public class Inventory : MonoBehaviour
{

    public IList<GamePiece> FairyPieces = new List<GamePiece>();

    public int ceiniog;

    public IList<GamePiece> Items = new List<GamePiece>();

    public int MaxMagic; //Defeating an enemy increases the number

    public string InventoryName;
    public TextMeshProUGUI InventoryElement;
    public string SpellbookName;
    public TextMeshProUGUI SpellbookElement;
    public string PiecesName;
    public TextMeshProUGUI PiecesElement;

    void Start()
    {
        //TODO get this from a savefile, currently for demo it's hard-coded from the start of the demo. 
        GamePiece paladin = new GamePiece("Paladin", 1);
        GamePiece barbarian = new GamePiece("Barbarian", 1);
        FairyPieces.Add(paladin);
        FairyPieces.Add(barbarian);
        ceiniog = 10; //We get 5 from Merlin and 5 from Lancelot, TODO change this from being hardcoded
        GamePiece bread = new GamePiece("Bread", 1);
        GamePiece sword = new GamePiece("Sword", 1);
        GamePiece bracelet = new GamePiece("Arthur's bff bracelet", 1);
        Items.Add(bread);
        Items.Add(sword);
        Items.Add(bracelet);

        PiecesName = ListToString(FairyPieces, true);
        PiecesElement.text = PiecesName;
        InventoryName = ListToString(Items, false);
        InventoryElement.text = InventoryName;
    }

    public void GetMoney()
    {
        ceiniog += 1;
    }

    public void GetItem(string itemName, int amount = 1)
    {
        int i = 0;
        do
        {
            if (FairyPieces[i].fairyPiece == itemName)
            {
                int q = FairyPieces[i].quantity + amount;
                FairyPieces[i] = new GamePiece(itemName, q);
                return;
            }
            i++;
        }
        while (i < FairyPieces.Count);
        GamePiece newItem = new GamePiece(itemName, amount);
        Items.Add(newItem);
        InventoryName = ListToString(Items, false);
        InventoryElement.text = InventoryName;
    }

    public void GetPiece(string pieceName)
    {
        int i = 0;
        do
        {
            if (FairyPieces[i].fairyPiece == pieceName)
            {
                int q = FairyPieces[i].quantity + 1;
                FairyPieces[i] = new GamePiece(pieceName, q);
                return;
            }
            i++;
        }
        while (i < FairyPieces.Count);
        GamePiece newPiece = new GamePiece(pieceName, 1);
        FairyPieces.Add(newPiece);
        PiecesName = ListToString(FairyPieces, true);
        PiecesElement.text = PiecesName;
    }

    string ListToString(IList<GamePiece> myList, bool isPiece)
    {
        string returnString;
        if (isPiece)
        {
            returnString = "Silver" + " x" + ceiniog.ToString();
        }
        else
        {
            returnString = "Anima" + " x" + MaxMagic.ToString();
        }
         
        int i = 0;
        do
        {
            returnString = returnString + "\n\n" + myList[i].fairyPiece + " x" + myList[i].quantity.ToString();
            i++;
        }
        while (i < myList.Count);
        
        return returnString;
    }


    public struct GamePiece
    {
        public GamePiece(string fairy, int q)
        {
            fairyPiece = fairy;
            quantity = q;
        }
        public string fairyPiece;
        public int quantity;
    }
}
