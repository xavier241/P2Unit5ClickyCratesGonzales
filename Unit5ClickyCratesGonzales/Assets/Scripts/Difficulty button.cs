using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Difficultybutton : MonoBehaviour
{
    public int difficulty;
    private GameManager gameManager;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(setDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setDifficulty() 
    {
        Debug.Log(button.gameObject.name + "was clicked");
        gameManager.StartGame(difficulty);
    }
}
