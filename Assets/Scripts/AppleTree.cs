using System.Collections;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [SerializeField] GameObject AppleInstance;
    [SerializeField] GameObject BadInstance;
	public float speed = 6f;
	[SerializeField] float leftAndRightEdge = 13f;
	public float chanceToChangeDirections = 0.01f;
	[SerializeField] float secondsBetweenAppleDrops = 0.5f;
    public int dropSpeed = -6;
    public float badDropChance = 0.1f;

    private int appleCounter = 0;
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

        if(appleCounter == 30){
            appleCounter = 0;
            Game.instance.NextRound();
        }
    }

    void FixedUpdate() {
        if (Random.value < chanceToChangeDirections) {
			speed *= -1;
		}
    }

    void DropApple(){
        appleCounter++;
        if (Random.value < badDropChance){
            GameObject newBad = Instantiate(BadInstance);
            newBad.transform.position = transform.position;
            newBad.GetComponent<Apple>().speed = dropSpeed;
            return;
        }
        GameObject newApple = Instantiate(AppleInstance);
        newApple.transform.position = transform.position;
        newApple.GetComponent<Apple>().speed = dropSpeed;
    }
}
