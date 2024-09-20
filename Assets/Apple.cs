using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,-9.8f*Time.deltaTime,0);
        if(transform.position.y < -9){
            print("basketloss");
            Game.instance.RemoveBasket();
            Destroy(gameObject);
        }
    }
}
