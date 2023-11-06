using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinManager : MonoBehaviour
{
    [SerializeField] int createCount = 20;
    [SerializeField] GameObject coin;

    [SerializeField] GameObject rootRotateItem;

    List<GameObject> coinList = new List<GameObject>();

    private float moveLength = 3.5f;
    int itemSpawnRate = 30; //아이템 생성 퍼센트
    System.Random rand = new System.Random();

    void Start()
    {
        //NewPosition();
        coinList.Capacity = createCount;
        CreateItem();

        coinList[coinList.Count - 1].GetComponent<MeshFilter>().mesh = Resources.Load<Mesh>("BatteryC");
        coinList[coinList.Count - 1].GetComponent<MeshRenderer>().material = Resources.Load<Material>("Battery");
    }

    public void CreateItem()
    {
        for(int i = 0; i < createCount; i++)
        {
            coinList.Add(Instantiate(coin, coin.transform.position + new Vector3(0, 0, i * 2), Quaternion.identity));
        }
    }

    public void RandomItem()
    {
        if(rand.Next(100) < itemSpawnRate)
        {
            //Debug.Log("magnet 생성");
            int itemIndex = rand.Next(createCount);

            coinList[itemIndex].SetActive(false);

        }
    }

    public void NewPosition()
    {
        transform.localPosition = new Vector3((rand.Next(3) - 1) * moveLength, 0, 0);

        foreach(var item in coinList)
        {
            item.gameObject.SetActive(true);
            item.transform.rotation = rootRotateItem.transform.rotation;
        }

        RandomItem();
    }
}
