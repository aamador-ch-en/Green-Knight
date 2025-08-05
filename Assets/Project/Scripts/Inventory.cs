using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public IList<GamePiece> FairyPieces = new List<GamePiece>();

    public int ceiniog;

    public IList<GamePiece> Items = new List<GamePiece>();

    public int MaxMagic; //Defeating an enemy increases the number

    void Start()
    {
        //TODO get this from a savefile, currently for demo it's hard-coded from the start of the demo. 
        GamePiece paladin = new GamePiece("paladin", 1);
        GamePiece barbarian = new GamePiece("barbarian", 1);
        FairyPieces.Add(paladin);
        FairyPieces.Add(barbarian);
        ceiniog = 10; //We get 5 from Merlin and 5 from Lancelot, TODO change this from being hardcoded
        GamePiece bread = new GamePiece("item bread", 1);
        GamePiece sword = new GamePiece("item sword", 1);
        GamePiece bracelet = new GamePiece("item Arthur's bff bracelet", 1);
        Items.Add(bread);
        Items.Add(sword);
        Items.Add(bracelet);
    }

    public void GetMoney()
    {
        ceiniog += 1;
    }

    public void GetItem(string itemName, int amount = 1)
    {
        GamePiece newItem = new GamePiece(itemName, amount);
        Items.Add(newItem);
    }
    

    public struct GamePiece
    {
        public GamePiece(string fairy, int q)
        {
            fairyPiece = fairy;
            quantity = q;
        }
        string fairyPiece;
        int quantity;
    }
}
