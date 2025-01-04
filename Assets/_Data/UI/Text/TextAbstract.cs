using TMPro;
using UnityEngine;

public class TextAbstract : TungMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textMeshProUGUI;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMeshPro();
    }
    protected virtual void LoadTextMeshPro()
    {
        if (this.textMeshProUGUI != null) return;
        this.textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + " : LoadTextMeshPro", gameObject);
    }
}
