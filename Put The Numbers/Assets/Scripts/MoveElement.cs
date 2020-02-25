using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveElement : MonoBehaviour
{
	public Button One, Two, Tree, Four, Five, Six, Seven, Eight, Nine, Ten;
	int buttonClicked = 0; bool panelclicked = false; float anchonum = 0;
	public List<Sprite> Sprites = new List<Sprite>();
	public List<Vector2> posNumbers = new List<Vector2>();
	public List<int> valNumbers = new List<int>();
	public GameObject GameEditorCanvas;
	public GameObject GamePlayCanvas;
    void Start(){
    	One.onClick.AddListener(AddOne);
    	Two.onClick.AddListener(AddTwo);
    	Tree.onClick.AddListener(AddTree);
    	Four.onClick.AddListener(AddFour);
    	Five.onClick.AddListener(AddFive);
    	Six.onClick.AddListener(AddSix);
    	Seven.onClick.AddListener(AddSeven);
    	Eight.onClick.AddListener(AddEight);
    	Nine.onClick.AddListener(AddNine);
    	Ten.onClick.AddListener(AddTen);
    }
    bool ComprobarColsionNumeros(Vector2 a){
    	foreach (Vector2 b in posNumbers){
    		float dist = anchonum/2;
    		if (a.x <= b.x+dist && a.x >= b.x-dist && a.y <= b.y+dist && a.y >= b.y-dist){
    			return true;
    		}
    	}
    	return false;
    }
    void Update(){
    	if (Input.GetMouseButtonUp(0)) {
            if (panelclicked == true && buttonClicked != 0) { panelclicked = false;
            	if (!ComprobarColsionNumeros(new Vector2(Input.mousePosition.x, Input.mousePosition.y))) { 
            		GameObject NewObj = new GameObject(); 
            		Image NewImage = NewObj.AddComponent<Image>();
            		RectTransform NewRect = NewObj.GetComponent<RectTransform>();
            		NewRect.SetPositionAndRotation(Input.mousePosition, new Quaternion(0, 0, 0, 1));
            		posNumbers.Add(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            		valNumbers.Add(buttonClicked);
            		NewRect.localScale = new Vector3(0.6f,0.6f,0.6f);
            		anchonum = NewRect.rect.width;
            		NewRect.SetParent(GetComponent<RectTransform>());
            		NewObj.SetActive(true);
            		switch (buttonClicked){
            			case 1: NewImage.sprite = Sprites[0]; break;
            			case 2: NewImage.sprite = Sprites[1]; break;
            			case 3: NewImage.sprite = Sprites[2]; break;
            			case 4: NewImage.sprite = Sprites[3]; break;
            			case 5: NewImage.sprite = Sprites[4]; break;
            			case 6: NewImage.sprite = Sprites[5]; break;
            			case 7: NewImage.sprite = Sprites[6]; break;
            			case 8: NewImage.sprite = Sprites[7]; break;
            			case 9: NewImage.sprite = Sprites[8]; break;
            			case 10: NewImage.sprite = Sprites[9]; break;
            		}
            	}
            }
        }
    }
	void AddOne(){ buttonClicked = 1; }
	void AddTwo(){ buttonClicked = 2; }
	void AddTree(){ buttonClicked = 3; }
	void AddFour(){ buttonClicked = 4; }
	void AddFive(){ buttonClicked = 5; }
	void AddSix(){ buttonClicked = 6; }
	void AddSeven(){ buttonClicked = 7; }
	void AddEight(){ buttonClicked = 8; }
	void AddNine(){ buttonClicked = 9; }
	void AddTen(){ buttonClicked = 10; }
	public void Play(){
		if (posNumbers.Count > 0){
			GameEditorCanvas.SetActive(false);
			GamePlayCanvas.SetActive(true);
		}
	}
	public void PanelClicked(){
		panelclicked = true;
	}
}
