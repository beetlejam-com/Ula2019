using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : Singleton<UIManger>
{
    [SerializeField] private GameMenu _mainMenu;
    [SerializeField] private PauseMenu _pauseMenu;

    [SerializeField] private Camera _dummyCamera;

    public Events.EventFadeComple OnMainMenuFadeComplete;

    private void Start()
    {
        _mainMenu.OnMainMenuFadeComplete.AddListener(HandleMainMenuFadeComplete);
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    void HandleMainMenuFadeComplete (bool fadeOut)
    {
        OnMainMenuFadeComplete.Invoke(fadeOut);
    }

    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        _pauseMenu.gameObject.SetActive(currentState == GameManager.GameState.PAUSED);
    }

    private void Update()
    {
        if(GameManager.Instance.CurentGameState != GameManager.GameState.PREGAME)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.StartGame();
        }
    }

    public void SetDummyCameraActive(bool active)
    {
        _dummyCamera.gameObject.SetActive(active);
    }
}
