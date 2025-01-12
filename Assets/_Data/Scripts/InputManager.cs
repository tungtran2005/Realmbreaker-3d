using UnityEngine;

public class InputManager : TungSingleton<InputManager>
{
    [SerializeField] protected bool attackChecking = false;
    public bool AttackChecking => attackChecking;
    [SerializeField] protected bool isHealing = false;
    public bool IsHealing => isHealing;


    private void Update()
    {
        this.CheckInput();
        this.CheckHealing();
    }
    protected virtual void CheckInput()
    {
        this.attackChecking = Input.GetButton("Fire1");
    }
    protected virtual void CheckHealing()
    {
        this.isHealing = Input.GetKeyDown(KeyCode.Alpha5);
    }
}
