using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinManager : MonoBehaviour
{
    [SerializeField] int createCount = 20;
    [SerializeField] GameObject coin;
    [SerializeField] GameObject magnet;
    [SerializeField] GameObject coinLootTransform;
    [SerializeField] GameObject rootRotateItem;

    List<GameObject> coinList = new List<GameObject>();
    List<GameObject> SpecialItemList = new List<GameObject>();

    [SerializeField] ItemManager itemManager;

    private float moveLength = 3.5f;
    int itemSpawnRate = 30; //아이템 생성 퍼센트
    System.Random rand = new System.Random();

    void Start()
    {
        //NewPosition();
        coinList.Capacity = createCount;
        CreateItem();
        coinLootTransform.SetActive(false);

        itemManager = GameObject.Find("Item Manager").GetComponent<ItemManager>();
    }

    public void CreateItem()
    {
        for(int i = 0; i < createCount; i++)
        {
            coinList.Add(Instantiate(coin, coinLootTransform.transform.position + new Vector3(0, 1, i * 2), Quaternion.identity));
            coinList[i].transform.parent = coinLootTransform.transform;
        }

        SpecialItemList.Add(Instantiate(magnet));
        foreach(var item in SpecialItemList)
        {
            item.transform.parent = coinLootTransform.transform;
            item.SetActive(false);
        }
    }

    public void RandomItem()
    {
        if(rand.Next(100) < itemSpawnRate)
        {
            //Debug.Log("magnet 생성");
            int itemIndex = rand.Next(createCount);
            SpecialItemList[0].transform.position = coinList[itemIndex].transform.position;
            coinList[itemIndex].SetActive(false);
            SpecialItemList[0].SetActive(true);


        }
    }

    public void NewPosition()
    {
        coinLootTransform.SetActive(true);
        transform.localPosition = new Vector3((rand.Next(3) - 1) * moveLength, 0, 0);

        foreach(var item in coinList)
        {
            item.gameObject.SetActive(true);
            item.transform.rotation = rootRotateItem.transform.rotation;
        }

        foreach(var item in SpecialItemList)
        {
            item.gameObject.SetActive(false);
            item.transform.rotation = rootRotateItem.transform.rotation;
        }

        RandomItem();
    }
}
