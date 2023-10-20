using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item, IItem
{
    [SerializeField] GameObject magnetCollider;
    GameObject magnetPosition;

    public void Use()
    {
        Debug.Log("Magnet");
        
        if(magnetPosition == null)
        {
            magnetPosition = Instantiate(magnetCollider);
        }

        magnetCollider.SetActive(true);

        StartCoroutine(EnableTime(magnetCollider));
    }

    IEnumerator EnableTime(GameObject magnet)
    {
        yield return new WaitForSecondsRealtime(10.0f);

        magnet.gameObject.SetActive(false);
    }
}
