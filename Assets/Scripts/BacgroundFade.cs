using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CuttingRoom;

public class BacgroundFade : MonoBehaviour
{

    [SerializeField]
    private HandTracking HandTracking;

    [SerializeField]
    private ImageController ImageController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HandTracking.xPosition < 0)
        {
            for (int y = 0; y < ImageController.image.height; y++)
            {
                for (int x = 0; x < ImageController.image.width; x++)
                {
                    ImageController.image.SetPixel(x, y, Color.clear);
                }
            }

        } 
        else if (HandTracking.xPosition > 0)
        {
            for(int y = 0; y < ImageController.image.height; y++)
            {
                for(int x = 0; x < ImageController.image.width; x++)
                {
                    ImageController.image.SetPixel(x,y,Color.white);
                    print("debug");
                }
            }
        }

        ImageController.image.Apply();
    }
}
