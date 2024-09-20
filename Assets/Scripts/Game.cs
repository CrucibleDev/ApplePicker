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
    [SerializeField] AudioSource audioSource;

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
    private int round = 1;

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
        score += 1 * round * (baskets.Length - basketIndex);
        scoreText.text = "Score: " + score;
    }

    public void PlaySound(AudioClip clipToPlay){
        audioSource.clip = clipToPlay;
        audioSource.Play();
    }

    public void NextRound(){
        if(round == 4){
            endGame();
        }
        appleTree.dropSpeed -= 3;
        appleTree.speed += 2;
        appleTree.chanceToChangeDirections += 0.005f;
        appleTree.badDropChance += 0.02f;

        round++;
        roundText.text = "Round: " + round;
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
        Destroy(basketPoint);
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
}
