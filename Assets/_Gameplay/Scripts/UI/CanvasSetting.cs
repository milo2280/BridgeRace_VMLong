using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSetting : UICanvas
{
    public void CloseButton()
    {
        UIManager.Ins.OpenUI(UIID.UICGamePlay);
        GameManager.Ins.ChangeState(GameState.Gameplay);

        Close();
    }

    public void RestartButton()
    {
        LevelManager.Ins.Restart();
    }
}
