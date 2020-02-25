using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GetPlayInfo : MonoBehaviour
{
	public GameObject GameViewPanel; public Text Time; public Text Score; MoveElement play_info; 
	List <Vector2> Numbers; List <GameObject> GONumbers = new List<GameObject>(); float anchonum = 0;
	int counterR = 11; int countime = 0; GameController gcontroller; int time, score;
    void Start() {
    	time = 50; score = 50; gcontroller = GameObject.FindWithTag("GameController").GetComponent<GameController>(); 
		play_info = GameViewPanel.GetComponent<MoveElement>(); 
    	Numbers = play_info.posNumbers;
        for (int i = 0; i < Numbers.Count; i++){
        	GameObject NewObj = new GameObject();
        	Image NewImage = NewObj.AddComponent<Image>();
        	RectTransform NewRect = NewObj.GetComponent<RectTransform>();
        	Vector3 position = new Vector3(Numbers[i].x, Numbers[i].y, 0.0f);
        	NewRect.SetPositionAndRotation(position, new Quaternion(0, 0, 0, 1));
        	NewRect.localScale = new Vector3(0.6f,0.6f,0.6f);
            anchonum = NewRect.rect.width;
            NewRect.SetParent(GetComponent<RectTransform>());
            NewObj.SetActive(true);
            switch (play_info.valNumbers[i]){
            	case 1: NewImage.sprite = play_info.Sprites[0]; break;
            	case 2: NewImage.sprite = play_info.Sprites[1]; break;
                case 3: NewImage.sprite = play_info.Sprites[2]; break;
                case 4: NewImage.sprite = play_info.Sprites[3]; break;
            	case 5: NewImage.sprite = play_info.Sprites[4]; break;
            	case 6: NewImage.sprite = play_info.Sprites[5]; break;
            	case 7: NewImage.sprite = play_info.Sprites[6]; break;
            	case 8: NewImage.sprite = play_info.Sprites[7]; break;
            	case 9: NewImage.sprite = play_info.Sprites[8]; break;
            	case 10: NewImage.sprite = play_info.Sprites[9]; break;
            }
            GONumbers.Add(NewObj);
        }
    }
    void Update() {
    	if (!VerifyGameOver()){
    	TimeCounter();
        if (Input.GetMouseButtonUp(0)) {
            for (int i = 0; i < Numbers.Count; i++){
            float dist = anchonum/2;
    		if (Input.mousePosition.x <= Numbers[i].x+dist && Input.mousePosition.x >= Numbers[i].x-dist 
    			&& Input.mousePosition.y <= Numbers[i].y+dist && Input.mousePosition.y >= Numbers[i].y-dist){
    			if (play_info.valNumbers[i] == MaxNumber(counterR)){
    				Numbers.Remove(Numbers[i]);
    				play_info.valNumbers.Remove(play_info.valNumbers[i]);
    				Destroy(GONumbers[i]);
    				GONumbers.Remove(GONumbers[i]); score+=5;
    			}
    			else{ score-=5; }
    			Score.text = score.ToString();
    		}
    	}
        }
    } else {
    	SceneManager.LoadScene("GameOver");
    }
    }
    bool ThisNumberIn(int a){
    	foreach (int b in play_info.valNumbers){
    		if (a == b){
    			return true;
    		}
    	}
    	return false;
    }
    int MaxNumber(int a){
    	int max = 0;
    	foreach (int b in play_info.valNumbers){
    		if (max < b && max <= a){
    			max = b;
    		}
    	}
    	return max;
    }
    bool VerifyGameOver(){
    	if (time <= 0 || score <= 0 || Numbers.Count == 0){
    		gcontroller.time = time; gcontroller.score = score;
            return true;
    	}
    	return false;
    }
    void TimeCounter(){
    	if (countime == 50 && time >= 0){
    		time = time - 1;
    		Time.text = time.ToString();
    		countime = 0;
    	}
    	else{
    		countime = countime + 1;
    	}
    }
}
