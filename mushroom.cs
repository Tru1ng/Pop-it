using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mushroom : MonoBehaviour
{
    public GameObject mush;
    public Vector3 SpawnValue;

    public int score,High;
    public Text ScoreGame, HighScore, TimerTXT;

    private float Timer = 120f;


    public void Awake()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            High = PlayerPrefs.GetInt("SaveScore");
        }
    }

    void Start()
    {
        MushroomSpawn();

    }

    void Update()
    {
        ScoreGame.text = score.ToString();
        HighScore.text = High.ToString();

        Score_Stable();

        //Game Timer until GameOver
        Timer_Game();
    }

    public void MushroomSpawn()
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(-SpawnValue.x, SpawnValue.x), SpawnValue.y, Random.Range(-SpawnValue.z, SpawnValue.z));

        Quaternion SpawnRotation = Quaternion.Euler(-89.98f,0f,0f);

        Instantiate(mush, SpawnPosition, SpawnRotation);
    }

    public void HighCheck()
    {
        if(score > High)
        {
            High = score;

            PlayerPrefs.SetInt("SaveScore", High);
        }
        

    }

    public void Score_Stable()
    {
        

        if (GameObject.FindGameObjectsWithTag("M").Length < 1)
        {
            MushroomSpawn();
            Addscore();
            

        }
    }

    public void Timer_Game()
    {
        //Timer for end game
        Timer -= Time.deltaTime;
        TimerTXT.text = Timer.ToString("#");

        if (Timer < 0)
        {
            //when timer get < 0 num, loading scene "GAME"
            SceneManager.LoadScene("Game");
        }

    }

    public void Addscore()
    {
        score++;
        HighCheck();
    }
}
