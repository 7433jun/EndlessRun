using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float offset = 40f;

    public static Action roadCallback;

    public void Start()
    {
        roadCallback = newPosition;
    }

    void Update()
    {
        foreach (var road in roads)
        {
            road.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    public void newPosition()
    {
        GameObject tempRoad = roads[0];
        roads.RemoveAt(0);
        float newZ = roads[roads.Count - 1].transform.position.z + offset;
        tempRoad.transform.position = new Vector3(0, 0, newZ);
        roads.Add(tempRoad);

        tempRoad.GetComponentInChildren<CoinManager>().NewPosition();
    }
}
