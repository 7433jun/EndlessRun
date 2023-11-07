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

    [SerializeField] GameObject optionPanel;

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
        buttonList[1].onClick.AddListener(B);
        buttonList[2].onClick.AddListener(Option);
        buttonList[3].onClick.AddListener(Quit);

        for(int i = 0; i < createCount; i++)
        {
            buttonList[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = buttonName[i];
        }
    }

    public void StartGame()
    {
        GameManager.instance.GameStart();
    }

    public void B()
    {

    }

    public void Option()
    {
        optionPanel.SetActive(true);
    }

    public void Quit()
    {
        //전처리 입력
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
