using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game instance;
    [SerializeField] AppleTree appleTree;
    [SerializeField] Basket[] basket;
    private int basketIndex = 0;
    private int score = 0;

    private void Awake()
    {
        CreateSingleton();
    }

    void CreateSingleton()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(){
        score++;
    }

    public void RemoveBasket(){
        Destroy(basket[basketIndex].gameObject);
        basketIndex++;
        if(basketIndex >= basket.Length){
            endGame();
        }
    }
    
    public void endGame(){
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
