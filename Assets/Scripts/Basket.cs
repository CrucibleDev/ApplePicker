using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] AudioClip appleSound;
    [SerializeField] AudioClip twigSound;

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = new Vector3(Input.mousePosition.x,0,0);
        screenPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        Vector3 newLocation = new Vector3(screenPoint.x,transform.position.y,transform.position.z);
        transform.position = newLocation;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Apple"){
            Game.instance.AddScore();
            Game.instance.PlaySound(appleSound);
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Twig"){
            Game.instance.endGame();
            Game.instance.PlaySound(twigSound);
            Destroy(other.gameObject);
        }
    }
}
