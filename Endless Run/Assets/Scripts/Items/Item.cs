using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 75.0f;

    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        transform.position += Vector3.back * GameManager.instance.speed * Time.deltaTime;
    }
}
