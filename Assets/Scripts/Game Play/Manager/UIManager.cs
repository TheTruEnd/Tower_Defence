using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Button hackBtn;
    public Button PauseBtn;
    public Button speedButton;
    public TextMeshProUGUI spiritStoneText;
    public TextMeshProUGUI livesLeftText;
    public TextMeshProUGUI waveNumberText;
    public TextMeshProUGUI waveNameText;
    public TextMeshProUGUI speedText;

    private int timeScale;
    private bool isPause = false;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite resumeSprite;

    protected override void Awake()
    {
        base.Awake();

        Time.timeScale = timeScale = 1;
        // speedText.text = "X" + Time.timeScale;
        spiritStoneText.text = "0";
        livesLeftText.text = "0";
        // waveNameText.text = "Wave 1";
        // waveNameText.alpha = 0f;
        // waveNumberText.text = "1/" + LevelManager.Instance.levelData.listWavesData.Count;

    }

    // private void OnEnable()
    // {
    //     this.RegisterListener(EventID.On_Spirit_Stone_Change, param => UpdateSpiritStone(int)(param));
    //     this.RegisterListener(EventID.On_Lives_Change, param => UpdateLives(int)(param));
    //     this.RegisterListener(EventID.On_Player_Win, param => HandlePlayerWin(int)(param));
    //     this.RegisterListener(EventID.On_Player_Lose, param => HandlePlayerLose(int)(param));
    //     
    //     hackBtn.onClick.AddListener(() => { LevelManager.Instance.SpriritStone += 1000; });
    //     PauseBtn.onClick.AddListener(PauseGame);
    //     speedButton.onClick.AddListener(ChangeGameSpeed);
    // }
    //
    // private void OnDisable()
    // {
    //     this.RemoveListener(EventID.On_Spirit_Stone_Change, param => UpdateSpiritStone(int)(param));
    //     this.RemoveListener(EventID.On_Lives_Change, param => UpdateLives(int)(param));
    //     this.RemoveListener(EventID.On_Player_Win, param => HandlePlayerWin(int)(param));
    //     this.RemoveListener(EventID.On_Player_Lose, param => HandlePlayerLose(int)(param));
    //     
    //     hackBtn.onClick.RemoveAllListeners();
    //     PauseBtn.onClick.RemoveAllListeners();
    //     speedButton.onClick.RemoveAllListeners();
    // }

    public void UpdateSpiritStone(int amount)
    {
        spiritStoneText.text = amount.ToString();
    }

    public void UpdateLives(int amount)
    {
        livesLeftText.text = amount.ToString();
    }
    
    //Hien thi ten Wave va sinh quai

    public IEnumerator ShowWaveName(int waveID)
    {
        yield return new WaitForSeconds(1f);

        waveNameText.text = "Wave" + (waveID + 1);
        waveNumberText.text = (waveID + 1) + "/" + LevelManager.Instance.levelData.listWavesData.Count;
        waveNameText.gameObject.SetActive(true);
        waveNameText.DOFade(1f, 0.5f);
        yield return new WaitForSeconds(1f);
        waveNameText.DOFade(0f, 0.5f);

        yield return new WaitForSeconds(1f);
        
        //Sinh quai cho wave
        LevelManager.Instance.CreateWave(waveID);
    }

    private void PauseGame()
    {
        if (!isPause)
        {
            Time.timeScale = 0f;
            isPause = true;
            PauseBtn.image.sprite = resumeSprite;
        }
    }

    private void ResumeGame()
    {
        Time.timeScale = timeScale;
        isPause = false;
        PauseBtn.image.sprite = pauseSprite;
    }

    private void ChangeGameSpeed()
    {
        if (timeScale == 1)
        {
            timeScale = 2;
        }
        else if (timeScale == 2)
        {
            timeScale = 4;
        }
        else
        {
            timeScale = 1;
        }

        speedText.text = "x" + timeScale;

        if (isPause)
        {
            Time.timeScale = timeScale;
        }
    }
}
