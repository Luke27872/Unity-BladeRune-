using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePickup : MonoBehaviour
{
    public RuneSlot runeSlot_script;
    public GameObject RuneSlots;

    public int runeValue;

    private void Start()
    {
        RuneSlots = GameObject.FindWithTag("RuneSlots");
        runeSlot_script = RuneSlots.GetComponent<RuneSlot>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            runeSlot_script.RuneInv(runeValue);
            Destroy(gameObject);
        }
    }
}
