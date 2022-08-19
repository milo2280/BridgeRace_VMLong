using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasVictory : UICanvas
{
    public void CloseButton()
    {
        LevelManager.Ins.Restart();

        Close();
    }

    public void NextLevelButton()
    {
        LevelManager.Ins.NextLevel();
        UIManager.Ins.OpenUI<CanvasGameplay>(UIID.UICGamePlay).OnInitData();

        Close();
    }
}
