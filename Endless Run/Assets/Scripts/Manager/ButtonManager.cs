using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Transform layout;
    [SerializeField] Button buttonPrefab;
    [SerializeField] int createCount = 4;

    List<Button> buttonList = new List<Button>();

    void Start()
    {
        buttonList.Capacity = createCount;

        CreateButton();
        Register();
    }

    void CreateButton()
    {
        for (int i = 0; i < createCount; i++)
        {
            buttonList.Add(Instantiate(buttonPrefab));
        }

        foreach (Button button in buttonList)
        {
            button.transform.SetParent(layout);
        }
    }

    void Register()
    {
        buttonList[0].onClick.AddListener(() => Debug.Log("A"));
        buttonList[1].onClick.AddListener(() => Debug.Log("B"));
        buttonList[2].onClick.AddListener(() => Debug.Log("C"));
        buttonList[3].onClick.AddListener(() => Debug.Log("D"));

        buttonList[0].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Start";
        buttonList[1].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Shop";
        buttonList[2].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Option";
        buttonList[3].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Quit";
    }
}
