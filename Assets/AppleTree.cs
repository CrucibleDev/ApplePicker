using System.Collections;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [SerializeField] GameObject AppleInstance;
    int dir = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        int rand = Random.Range(0,100);
        if(rand < 10){
            dir *= -1;
        }
        transform.Translate(10 * Time.deltaTime * dir,0,0);
    }

    IEnumerator MyCoroutine()
    {
        while(true){
            yield return new WaitForSeconds(0.5f);
            GameObject newApple = Instantiate(AppleInstance);
            newApple.transform.position = transform.position;
        }
    }
}
