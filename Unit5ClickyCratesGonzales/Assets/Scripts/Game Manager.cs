using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    private int score;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public List<GameObject> targets;
    public GameObject[] target2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
        
       
    }
    void UpdateScore(int scoreToAdd) 
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }
}
