using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPlayerLevel : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadPlayerLevel();
    }
    protected virtual void LoadPlayerLevel()
    {
        this.textMeshProUGUI.text = PlayerCtrl.Instance.Level.CurrentLevel.ToString();
    }
}
