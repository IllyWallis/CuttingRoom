using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CuttingRoom.VariableSystem.Variables;
using CuttingRoom;

public class SetVariableOnHand : MonoBehaviour
{
    [SerializeField]
    private VariableSetter variableSetter = null;

    [SerializeField]
    private NarrativeObject NarrativeObject = null;

    [SerializeField]
    private HandTracking HandTracking = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(NarrativeObject != null && NarrativeObject.VariableStore != null)
        {
            var hasPlayedVariable = NarrativeObject.VariableStore.GetVariable("hasPlayed") as BoolVariable;

            if (hasPlayedVariable.value && variableSetter != null)
            {
                if(HandTracking.xPosition < 0 )
                {
                    variableSetter.Set("left");
                } else if (HandTracking.xPosition > 0)
                {
                    variableSetter.Set("right");
                }
            }
        }
    }
}
