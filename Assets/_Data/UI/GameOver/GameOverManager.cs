using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : TungSingleton<GameOverManager>
{
    [SerializeField] protected GameObject gameOverCanvas;
    [SerializeField] protected bool isShow = false;
    public bool IsShow => isShow;


    protected override void Start()
    {
        base.Start();
        this.HideCanvas();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameOverCanvas();
    }
    protected virtual void LoadGameOverCanvas()
    {
        if (this.gameOverCanvas != null) return;
        this.gameOverCanvas = GameObject.Find("GameOverCanvas");
        Debug.Log(transform.name + " : LoadGameOverCanvas", gameOverCanvas);
    }
    protected virtual void HideCanvas()
    {
        this.gameOverCanvas.SetActive(false);
        this.isShow = false;
    }
    public virtual void GameOver()
    {
        this.gameOverCanvas.SetActive(true);
        this.isShow = true;
        Time.timeScale = 0;
    }
    public virtual void GameReStart()
    {
        this.gameObject.SetActive(false);
        this.isShow = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
