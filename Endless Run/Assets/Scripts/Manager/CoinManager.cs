using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinManager : MonoBehaviour
{
    [SerializeField] int createCount = 15;
    [SerializeField] GameObject coin;
    List<GameObject> itemList = new List<GameObject>();

    Vector3 leftPosition = new Vector3(-3.5f, 0, 0);
    Vector3 middlePosition = Vector3.zero;
    Vector3 rightPosition = new Vector3(3.5f, 0, 0);

    
    

    void Start()
    {
        CreateCoin();
    }

    void Update()
    {
        
    }

    public void CreateCoin()
    {
        for(int i = 0; i < createCount; i++)
        {
            itemList.Add(Instantiate(coin, this.transform.position + new Vector3(0, 1, i * 2), Quaternion.identity));
            itemList[i].transform.parent = this.transform;
        }
    }
}
