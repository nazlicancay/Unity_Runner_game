using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    int _levelToLoad;

    private void Awake()
    {

        _levelToLoad = PlayerPrefs.GetInt("Level");

        if(_levelToLoad == 0)
        {
            // First time
            PlayerPrefs.SetInt("Level", 1);
            _levelToLoad = 1;
        }
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_levelToLoad);
    }

}
