using System.Collections;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [SerializeField] GameObject AppleInstance;
	[SerializeField] float speed = 1f;
	[SerializeField] float leftAndRightEdge = 13f;
	[SerializeField] float chanceToChangeDirections = 0.1f;
	[SerializeField] float secondsBetweenAppleDrops = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating( "DropApple", 2f, secondsBetweenAppleDrops );
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime,0,0);
        if (transform.position.x < -leftAndRightEdge ) {
			speed *= -1;
		} else if (transform.position.x > leftAndRightEdge ) {
			speed *= -1;
		} 
    }

    void FixedUpdate() {
        Debug.Log(Random.value);
        if (Random.value < chanceToChangeDirections) {
			speed *= -1;
		}
    }

    void DropApple(){
        GameObject newApple = Instantiate(AppleInstance);
        newApple.transform.position = transform.position;
    }
}
