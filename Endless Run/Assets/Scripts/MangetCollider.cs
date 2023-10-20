using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MangetCollider : MonoBehaviour
{
    List<GameObject> dragedCoins = new List<GameObject>();
    [SerializeField] Transform playerTransform;

    private void Start()
    {
        dragedCoins.Capacity = 20;
    }

    private void Update()
    {
        foreach(var coin in dragedCoins)
        {
            coin.transform.position = Vector3.Lerp(coin.transform.position, playerTransform.position, 0.01f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Coin>() != null)
        {
            dragedCoins.Add(other.gameObject);
        }
    }

    private void OnDisable()
    {
        dragedCoins.Clear();
    }
}
