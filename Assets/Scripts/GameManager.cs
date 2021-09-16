using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject camera;
    public bool isGameActive = true;
    public bool levelUp = false;
    public static GameManager gameManagerInstance;
    public TextMeshProUGUI gameOverText;
    public Button levelUpBotton;
    public Button startFromBeginingBotton;

    public int levelnum;
    [FormerlySerializedAs("LevelToLoad")] public int levelToLoad;

    public int speed;

    private void Awake()
    {
        gameManagerInstance = this;
       levelToLoad = PlayerPrefs.GetInt("Level");

    }
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive )
        {
            MoveForward(player,speed);
        }
        if(isGameActive == false && levelUp == false)
        {
            gameOverText.gameObject.SetActive(true);
        }

    }

    public void MoveForward(GameObject gameObject, int speed)
    {
        gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartLevel()
    {
        levelToLoad = PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene(levelToLoad);

    }

    public void StartFromBeggining()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(1);


    }





}
