using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMainMenu : UICanvas
{
    public void PlayGameButton()
    {
        UIManager.Ins.OpenUI<CanvasGameplay>(UIID.UICGamePlay).OnInitData();
        GameManager.Ins.ChangeState(GameState.Gameplay);

        Close();
    }

    public void SettingButton()
    {
        UIManager.Ins.OpenUI(UIID.UICSetting);
        GameManager.Ins.ChangeState(GameState.Pause);

        Close();
    }
}
