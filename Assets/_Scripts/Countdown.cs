using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public GameObject Three, Two, One;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        Time.timeScale = 0;
        
        Instantiate(Three, transform.position, Quaternion.identity);
        Destroy(Three);
        yield return new WaitForSecondsRealtime(1);
        Instantiate(Two, transform.position, Quaternion.identity);
        Destroy(Two);
        yield return new WaitForSecondsRealtime(1);
        Instantiate(One, transform.position, Quaternion.identity);
        Destroy(One);
        yield return new WaitForSecondsRealtime(1);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
