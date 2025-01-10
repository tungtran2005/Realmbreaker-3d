using UnityEngine;

public class ReStartBtn : ButtonAbstract
{
    protected override void OnClick()
    {
        GameOverManager.Instance.GameReStart();
    }
}
