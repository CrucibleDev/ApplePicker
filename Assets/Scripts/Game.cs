using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [HideInInspector] public static Game instance;

    [Header("Game Data")]
    [SerializeField] AppleTree appleTree;

    [Header("UI Data")]
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TextMeshPro scoreText;
    [SerializeField] TextMeshPro roundText;
    
    [Header("Basket Data")]
    [SerializeField] GameObject basketPoint;
    [SerializeField] GameObject basketPrefab;
    [SerializeField] int numBaskets = 4;
    [SerializeField] float basketOffset = 0.6f;
    GameObject[] baskets;
    private int basketIndex = 0;
    private int score = 0;

    private void Awake()
    {
        CreateSingleton();
        InstantiateBaskets();
        gameOverUI.SetActive(false);
        Time.timeScale = 1;
    }

    void CreateSingleton()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void InstantiateBaskets(){
        baskets = new GameObject[numBaskets];
        float offsetY = numBaskets * basketOffset;
        for (int i = 0; i < numBaskets; i++)
        {
            baskets[i] = Instantiate(basketPrefab, basketPoint.transform);
            baskets[i].transform.Translate(new Vector3(0,offsetY,0));
            offsetY -= basketOffset;
        }
    }

    public void AddScore(){
        score++;
        scoreText.text = "Score: " + score;
    }

    public void RemoveBasket(){
        Destroy(baskets[basketIndex].gameObject);
        basketIndex++;
        if(basketIndex >= baskets.Length){
            endGame();
        }
    }

    public void endGame(){
        //Pause
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
}
