using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGameplay : UICanvas
{
    public Text currentLevelText;

    public void SettingButton()
    {
        UIManager.Ins.OpenUI(UIID.UICSetting);
        GameManager.Ins.ChangeState(GameState.Pause);

        Close();
    }

    public void OnInitData()
    {
        currentLevelText.text = LevelManager.Ins.currentLevelText;
    }

    private void Update()
    {
        if (LevelManager.Ins.endGameUI > 0)
        {
            if (LevelManager.Ins.endGameUI == 1) Victory();
            else if (LevelManager.Ins.endGameUI == 2) Fail();
        }

    }

    public void Victory()
    {
        UIManager.Ins.OpenUI(UIID.UICVictory);

        Close();
    }

    public void Fail()
    {
        UIManager.Ins.OpenUI(UIID.UICFail);

        Close();
    }
}
