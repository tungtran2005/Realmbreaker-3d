using UnityEngine;

public class BtnCloseSetting : ButtonAbstract
{
    public override void OnClick()
    {
        UISetting.Instance.Hide();
    }
}
