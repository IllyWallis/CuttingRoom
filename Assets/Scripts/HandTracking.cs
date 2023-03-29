using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Linq;
using CuttingRoom.UI;
using CuttingRoom.VariableSystem.Variables;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HandTracking : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject[] handPoints;
    //
    //
    //
    //
    //my code starts here
    //
    //
    //
    //
    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);
    public GameObject hand;

    Vector3 tmpScreenPos;


    public float xPosition = 0;
    Vector3[] pastPosition = new Vector3[100];

    public GameObject leftWall;
    public GameObject rightWall;

    private void Start()
    {
        for (int i = 0; i < pastPosition.Length; i++)
        {
            pastPosition[i] = Vector3.zero;
        }
        
    }

    //
    //
    //
    //
    //my code ends here
    //
    //
    //
    //

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;

        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        //print(data);
        string[] points = data.Split(',');
        //print(points[0]);

        //0        1*3      2*3
        //x1,y1,z1,x2,y2,z2,x3,y3,z3

        for (int i = 0; i < 21; i++)
        {

            float x = 7 - float.Parse(points[i * 3]) / 100;
            float y = float.Parse(points[i * 3 + 1]) / 100;
            float z = float.Parse(points[i * 3 + 2]) / 100;

            handPoints[i].transform.localPosition = new Vector3(x, y, z);

        }

        //
        //
        //
        //
        //my code starts here
        //
        //
        //
        //
        xPosition = hand.transform.position.x;
        print(xPosition);


        // cursor stuff, broken,cool but might delete because :hover doesnt work with it
        for (int i = 0; i < pastPosition.Length -1; i++)
        {
            pastPosition[i] = pastPosition[i + 1];
        }
        pastPosition[pastPosition.Length - 1] = hand.transform.position;

        if (!areSame(pastPosition))
        {
            tmpScreenPos = Camera.main.WorldToScreenPoint(hand.transform.position);
            //print(tmpScreenPos.x);
            SetCursorPos((int) tmpScreenPos.x+ 175, Screen.height - (int) tmpScreenPos.y +140);
        } //

        // modifying css of first game using hand

        if(xPosition < 0)
        {
            //hand is on left of the screen
            leftWall.SetActive(false);
            rightWall.SetActive(true);
        }
        if(xPosition > 0)
        {
            //hand is on right of the creen
            rightWall.SetActive(false);
            leftWall.SetActive(true);
        }

        //
        //
        //
        //
        //my code ends here
        //
        //
        //
        //

    }

    public static bool areSame(Vector3[] arr)
    {

        // Put all array elements in a HashSet
        HashSet<Vector3> s = new HashSet<Vector3>();
        for (int i = 0; i < arr.Length; i++)
            s.Add(arr[i]);

        // If all elements are same, size of
        // HashSet should be 1. As HashSet
        // contains only distinct values.
        return (s.Count == 1);
    }


}
