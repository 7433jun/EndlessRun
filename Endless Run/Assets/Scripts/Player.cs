using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float positionX;

    [SerializeField] ObjectSound objectSound = new ObjectSound();

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
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Time.timeScale != 0)
        {
            AudioManager.instance.Sound(objectSound.audioClip[0]);

            positionX -= moveLength;
            SetPosition();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && Time.timeScale != 0)
        {
            AudioManager.instance.Sound(objectSound.audioClip[0]);

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

    private void OnTriggerEnter(Collider other)
    {
        IItem item= other.GetComponent<IItem>();

        if (item != null)
        {
            item.Use();
            other.gameObject.SetActive(false);
        }
    }
}
