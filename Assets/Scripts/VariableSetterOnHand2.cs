using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CuttingRoom.VariableSystem.Variables;
using CuttingRoom;

public class VariableSetterOnHand2 : MonoBehaviour
{
    [SerializeField]
    private VariableSetter variableSetter = null;

    [SerializeField]
    private NarrativeObject NarrativeObject = null;

    [SerializeField]
    private HandTracking HandTracking = null;

    private float timer = 0;
    private bool flag1 = false;
    private bool flag2 = false;
    private bool flag3 = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (NarrativeObject != null && NarrativeObject.VariableStore != null)
        {
            var hasPlayedVariable = NarrativeObject.VariableStore.GetVariable("hasPlayed") as BoolVariable;

            if (hasPlayedVariable.value && variableSetter != null)
            {

                if (HandTracking.xPosition < -2)
                {
                    if (flag1 == false)
                    {
                        timer = Time.time;
                        flag1 = true;
                        flag2 = false;
                        flag3 = false;
                    }

                    print(Time.time - timer);

                    if (Time.time - timer >= 5)
                    {
                        timer = 0;
                        variableSetter.Set("Wrong");
                    }
                }
                else if (HandTracking.xPosition > -2 && HandTracking.xPosition < 2)
                {
                    if(flag2 == false)
                    {
                        timer = Time.time;
                        flag1 = false;
                        flag2 = true;
                        flag3 = false;
                    }

                    print(Time.time - timer);

                    if (Time.time-timer >= 5)
                    {
                        timer = 0;
                        variableSetter.Set("Wrong");
                    }
                    
                }
                else if (HandTracking.xPosition > 2)
                {
                    if (flag3 == false)
                    {
                        timer = Time.time;
                        flag1 = false;
                        flag2 = false;
                        flag3 = true;

                        
                    }
                    //print(timer);
                    print(Time.time - timer);

                    if (Time.time - timer >= 5)
                    {
                        timer = 0;
                        variableSetter.Set("Correct");
                    }
                }
            }
        }
    }
}
