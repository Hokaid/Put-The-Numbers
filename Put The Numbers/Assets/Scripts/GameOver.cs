using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	GameController gcontroller; public GameObject Gameover, GoodWork;
	public Text Score; public Text Time;
    // Start is called before the first frame update
    void Start()
    {
    	gcontroller = GameObject.FindWithTag("GameController").GetComponent<GameController>(); 
    	if (gcontroller.time <= 0 || gcontroller.score <= 0){
    		Gameover.SetActive(true); gcontroller.score = 0;
    	}
    	else {
    		GoodWork.SetActive(true);
    	}
    	Score.text = "Score: " + gcontroller.score.ToString();
    	Time.text = "Time: " + (50 - gcontroller.time).ToString();
    }

    public void TryAgain(){
    	gcontroller.time = 50; gcontroller.score = 50;
    	SceneManager.LoadScene("GameEditor");
    }
}
