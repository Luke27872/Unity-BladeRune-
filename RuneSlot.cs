using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneSlot : MonoBehaviour
{
    public Sprite[] Runes;
    public string[] Slots;

    public Image Slot1;
    public Image Slot2;
    public Image Slot3;

    public void RuneInv(int runeValue)
    {
        if (Slots[0] == "Empty")
        {
            Slot1.sprite = Runes[runeValue];
            Slots[0] = "Full";
        }
        else if (Slots[1] == "Empty")
        {
            Slot2.sprite = Runes[runeValue];
            Slots[1] = "Full";
        }
        else if (Slots[2] == "Empty")
        {
            Slot3.sprite = Runes[runeValue];
            Slots[2] = "Full";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            Slots[0] = "Empty";
            Slot1.sprite = Runes[0];
            Slots[1] = "Empty";
            Slot2.sprite = Runes[0];
            Slots[2] = "Empty";
            Slot3.sprite = Runes[0];
        }

        if (Slot1.sprite == Runes[0] && Slot2.sprite == Runes[1])
        {
            Debug.Log("test");

            Slots[0] = "Empty";
            Slot1.sprite = Runes[0];
            Slots[1] = "Empty";
            Slot2.sprite = Runes[0];
            Slots[2] = "Empty";
            Slot3.sprite = Runes[0];

        }
    }
}
