using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item, IItem
{
    [SerializeField] GameObject magnetColliderbox;
    GameObject magnetPosition;

    public void Use()
    {
        Debug.Log("Magnet");
    }
}
