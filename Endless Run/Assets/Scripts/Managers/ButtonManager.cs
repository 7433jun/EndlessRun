using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Transform layout;
    [SerializeField] Button buttonPrefab;
    [SerializeField] int createCount = 4;

    List<Button> buttonList = new List<Button>();
    [SerializeField] string[] buttonName;

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
        buttonList[0].onClick.AddListener(StartGame);
        buttonList[1].onClick.AddListener(() => Debug.Log("B"));
        buttonList[2].onClick.AddListener(() => Debug.Log("C"));
        buttonList[3].onClick.AddListener(() => Debug.Log("D"));

        for(int i = 0; i < createCount; i++)
        {
            buttonList[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = buttonName[i];
        }
    }

    public void StartGame()
    {
        GameManager.instance.GameStart();
    }
}
