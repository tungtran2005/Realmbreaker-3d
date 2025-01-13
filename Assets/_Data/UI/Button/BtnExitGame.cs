using UnityEngine;

public class BtnExitGame : ButtonAbstract
{
    public override void OnClick()
    {
        this.QuitGame();
    }
    public virtual void QuitGame()
    {

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
