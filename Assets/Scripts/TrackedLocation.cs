using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TrackedLocation : MonoBehaviour
{

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);
    public GameObject hand;


    Vector3 tmpScreenPos;


    public float xPosition = 0;
    Vector3[] pastPosition;
    Vector3[] placeHolder;
    // Start is called before the first frame update
    void Start()
    {
        pastPosition = new Vector3[10];
        placeHolder = new Vector3[10];

        for(int i = 0; i < pastPosition.Length; i++) {
            placeHolder[i] = new Vector3(0,0,0);
            pastPosition[i] = new Vector3(0,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        xPosition = hand.transform.position.x;

        for(int i = 0; i < pastPosition.Length; i++) {
            placeHolder[i] = pastPosition[i];
            if(i == 0) {
                pastPosition[i] = hand.transform.position;
            } else {
                pastPosition[i] = placeHolder[i-1];
            }
            print(placeHolder[i]);
            print(pastPosition[i]);
            
        }

        tmpScreenPos = Camera.main.WorldToScreenPoint(hand.transform.position);
        //SetCursorPos((int) tmpScreenPos.x, Screen.height - (int) tmpScreenPos.y);
    }
}
