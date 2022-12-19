using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public Ball ball { get; private set; }

    public Paddle paddle { get; private set; }

    public Brick[] bricks { get; private set; }

    


    
    public int scene = 1;
    public int score = 0;
    public int lives = 1;

    

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;

        
    }

    private void Start()
    {
        NewGame();

    }

    private void NewGame()
    {
        this.score = 0;
        this.lives = 1;

        LoadScene(1);
    }

    private void LoadScene(int scene)
    {
        this.scene = scene;

        SceneManager.LoadScene("Main");
        
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
        this.bricks = FindObjectsOfType<Brick>();
        
        
    }

    private void ResetLevel()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
    }

    
    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        
    }
    
    public void Miss()
    {
        this.lives--;

        if (this.lives > 0)
        {
            ResetLevel();
        }
        else
        {
            
            GameOver();
        }
    }

    public void Hit(Brick brick)
    {
        this.score += brick.points;
        
        //look into this
        ScoreText.instance.updateScore();

        

        if (Cleared())
        {
            SceneManager.LoadScene("LevelPassed");
            
        }
        
    }

    private bool Cleared()
    {
        for (int i = 0; i < this.bricks.Length; i++)
        {
            if (this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable)
            {
                return false;
            }
        }
        return true;
    }

    

}
