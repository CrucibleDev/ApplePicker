using System.Collections;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [SerializeField] GameObject AppleInstance;
    [SerializeField] GameObject BadInstance;
	[SerializeField] float speed = 1f;
	[SerializeField] float leftAndRightEdge = 13f;
	[SerializeField] float chanceToChangeDirections = 0.1f;
	[SerializeField] float secondsBetweenAppleDrops = 0.5f;
    [SerializeField] float badDropChance = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating( "DropApple", 1f, secondsBetweenAppleDrops );
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
        if (Random.value < chanceToChangeDirections) {
			speed *= -1;
		}
    }

    void DropApple(){
        if (Random.value < badDropChance){
            GameObject newBad = Instantiate(BadInstance);
            newBad.transform.position = transform.position;
            return;
        }
        GameObject newApple = Instantiate(AppleInstance);
        newApple.transform.position = transform.position;
    }
}
