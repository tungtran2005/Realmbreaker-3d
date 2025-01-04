using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObject/ItemProfile", order = 1 )]
public class ItemProfileSO : ScriptableObject
{
    public string itemName;
    public ItemCode itemCode;
}
