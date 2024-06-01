using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public void MoveTo(Vector3 newDestination)
    {
        //transform.position = destination; 
        
        timeErapsed = 0;

        origin = destination;
        transform.position = origin;

        destination = newDestination;
    }

    //完了までにかかる時間
    private float timeTaken = 0.2f;
    //経過時間
    private float timeErapsed;
    //目的地
    private Vector3 destination;
    //出発地
    private Vector3 origin;



    // Start is called before the first frame update
    void Start()
    {
        //目的地・出発地を現在地で初期化
        destination = transform.position;
        origin = destination;
    }

    // Update is called once per frame
    void Update()
    {
        if(origin == destination)
        {
            return;
        }
        timeErapsed += Time.deltaTime;

        float timeRate = timeErapsed / timeTaken;


        if(timeRate > 1)
        {
            timeRate = 1;
        }
        float easing = timeRate;

        Vector3 currentPosition = Vector3.Lerp(origin, destination, easing);

        transform.position = currentPosition;
    }
}
