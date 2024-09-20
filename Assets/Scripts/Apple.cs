using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,-6f*Time.deltaTime,0);
        if(gameObject.tag != "Apple"){
            return;
        }
        if(transform.position.y < -9){
            Game.instance.RemoveBasket();
            Destroy(gameObject);
        }
    }
}
