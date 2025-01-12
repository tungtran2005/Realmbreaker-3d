using UnityEngine;

public class ReStartBtn : ButtonAbstract
{
    public override void OnClick()
    {
        GameOverManager.Instance.GameReStart();
    }
}
