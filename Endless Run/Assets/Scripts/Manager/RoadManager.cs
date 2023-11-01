using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads;

    [SerializeField] float offset = 40f;
    [SerializeField] int count = 0;
    [SerializeField] int maxCount;

    public static Action roadCallback;

    public void Start()
    {
        roads.Capacity = 4;

        roadCallback = newPosition;
        roadCallback += Increase;
    }

    void Update()
    {
        foreach (var road in roads)
        {
            road.transform.Translate(Vector3.back * GameManager.instance.speed * Time.deltaTime);
        }
    }

    public void newPosition()
    {
        GameObject tempRoad = roads[0];
        roads.RemoveAt(0);
        float newZ = roads[roads.Count - 1].transform.position.z + offset;
        tempRoad.transform.position = new Vector3(0, 0, newZ);
        roads.Add(tempRoad);
    }

    public void Increase()
    {
        if(count < maxCount)
        {
            GameManager.instance.speed += Util.IncreaseValue(count++);
        }
    }
}
