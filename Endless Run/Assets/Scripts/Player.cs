using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1,
}

public class Player : MonoBehaviour
{
    [SerializeField] float positionX;

    private float moveLength = 3.5f;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            positionX -= moveLength;
            SetPosition();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            positionX += moveLength;
            SetPosition();
        }

        //transform.position = Vector3.Lerp(transform.position, new Vector3(positionX, 0f, 0f), 0.01f);
    }

    private void SetPosition()
    {
        positionX = Mathf.Clamp(positionX, -moveLength, moveLength);
        gameObject.transform.position = new Vector3(positionX, 0f, 0f);
    }
}
