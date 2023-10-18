using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinManager : MonoBehaviour
{
    [SerializeField] int createCount = 20;
    [SerializeField] GameObject coin;
    [SerializeField] GameObject coinLootTransform;
    List<GameObject> itemList = new List<GameObject>();

    private float moveLength = 3.5f;
    System.Random rand = new System.Random();

    void Start()
    {
        //NewPosition();
        CreateCoin();
        coinLootTransform.SetActive(false);
    }

    public void CreateCoin()
    {
        for(int i = 0; i < createCount; i++)
        {
            itemList.Add(Instantiate(coin, coinLootTransform.transform.position + new Vector3(0, 1, i * 2), Quaternion.identity));
            itemList[i].transform.parent = coinLootTransform.transform;
        }
    }

    public void NewPosition()
    {
        coinLootTransform.SetActive(true);
        transform.localPosition = new Vector3((rand.Next(3) - 1) * moveLength, 0, 0);
    }
}
