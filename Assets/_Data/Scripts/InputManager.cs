using UnityEngine;

public class InputManager : TungSingleton<InputManager>
{
    [SerializeField] protected bool attackChecking = false;
    public bool AttackChecking => attackChecking;

    private void Update()
    {
        this.CheckInput();
    }
    protected virtual void CheckInput()
    {
        this.attackChecking = Input.GetButton("Fire1");
    }
}
