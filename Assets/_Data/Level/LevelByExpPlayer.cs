using UnityEngine;

public class LevelByExpPlayer : LevelByItem
{
    protected override ItemCode GetItemCode()
    {
        return ItemCode.ExpPlayer;
    }
}
