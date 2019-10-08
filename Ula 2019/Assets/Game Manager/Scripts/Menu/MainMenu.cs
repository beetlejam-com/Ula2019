﻿using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;



public class MainMenu : MonoBehaviour
{
    [SerializeField] private Transform LevelButton;

    private float mainUnitWidth;
    private float mainUnitHeight;
    private float prefabWidth;
    private float prefabHeight;
    private int levelsInLine;
    private int levelsInColumn;
    private int marginLeft;
    private int marginRight;
    private int marginTop;
    private int marginBottom;
    private float menuMarginLeft;
    private float menuMarginTop;
    private int levelsAmount;

    void Awake()
    {
        marginLeft = marginRight = 10;
        marginTop = 40;
        marginBottom = 10;
        levelsAmount = 5;

        mainUnitWidth = GetComponent<RectTransform>().rect.width;
        mainUnitHeight = GetComponent<RectTransform>().rect.height;
        prefabWidth = LevelButton.GetComponent<RectTransform>().rect.width + marginLeft + marginRight;
        prefabHeight = LevelButton.GetComponent<RectTransform>().rect.height + marginTop + marginBottom;
        levelsInLine = (int)(mainUnitWidth / prefabWidth);
        levelsInColumn = (int)(mainUnitHeight / prefabHeight);
        menuMarginLeft = (mainUnitWidth - prefabWidth * levelsInLine) / 2;
        menuMarginTop = (mainUnitHeight - prefabHeight * levelsInColumn) / 2;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    private void Start()
    {
        int countX = 0;
        int countY = levelsInColumn-1;

        Social.localUser.Authenticate(authenticated =>
        {
            if (!authenticated || !Social.localUser.authenticated)
            {
                Debug.Log("fail");
            }
            Debug.Log("success");
            Social.LoadScores("leaderboard_level_1", scores => {

                Debug.Log(scores);
            });
        });

        

        for (int i = 0; i < levelsAmount; i++)
        {
            Transform _levelButton;

            _levelButton = Instantiate(LevelButton, transform.position + 
                new Vector3(countX * prefabWidth - mainUnitWidth / 2 + prefabWidth / 2 + menuMarginLeft, 
                countY * prefabHeight - mainUnitHeight / 2 + prefabHeight / 2 + menuMarginTop, 0), Quaternion.identity);
            _levelButton.transform.SetParent(transform);

            _levelButton.GetChild(0).GetComponent<TextMeshProUGUI>().text = (i+1).ToString();
            _levelButton.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Your score is 000, you are 20th";

            _levelButton.GetComponent<Button>().onClick.AddListener(HandleLevelClicked);

            countX++;
            if (countX >= levelsInLine)
            {
                countX = 0;
                countY--;
            }
            if (countY < 0) return;

        }

        

    }

    void HandleLevelClicked()
    {
        Debug.Log("Level Button Clicked!");
        GameManager.Instance.StartLevel();
    }
}
