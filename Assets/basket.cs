using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{
    [SerializeField] int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = new Vector3(Input.mousePosition.x,0,0);
        screenPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        Vector3 newLocation = new Vector3(screenPoint.x,transform.position.y,transform.position.z);
        transform.position = newLocation;
    }

    private void OnCollisionEnter(Collision other) {
        print(other.gameObject.tag);
        if(other.gameObject.tag == "Apple"){
            print("COLLISOIN");
            Destroy(other.gameObject);
            score++;
        }
    }
}
