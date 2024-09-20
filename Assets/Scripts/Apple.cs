using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public int speed = -6;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,speed*Time.deltaTime,0);
        if(gameObject.tag != "Apple"){
            if(transform.position.y < -9){
                Destroy(gameObject);
            }
            return;
        }
        if(transform.position.y < -9){
            Game.instance.RemoveBasket();
            Destroy(gameObject);
        }
    }
}
