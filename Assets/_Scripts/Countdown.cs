using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public GameObject threePrefab, twoPrefab, onePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        Time.timeScale = 0;
        
        var three = Instantiate(threePrefab, transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(1);
        Destroy(three);
        var two = Instantiate(twoPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(1);
        Destroy(two);
        var one = Instantiate(onePrefab, transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(1);
        Destroy(one);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
