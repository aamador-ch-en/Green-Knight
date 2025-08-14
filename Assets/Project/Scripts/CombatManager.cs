using TMPro;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject InventoryObj;
    public TextMeshProUGUI Spells;
    public TextMeshProUGUI Pieces;
    void StartGame()
    {
        Spells.text = InventoryObj.GetComponent<Inventory>().MaxMagic.ToString() + " anima";
        Pieces.text = InventoryObj.GetComponent<Inventory>().PiecesName;
    }
}
