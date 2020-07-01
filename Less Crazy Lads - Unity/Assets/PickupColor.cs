using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupColor : MonoBehaviour
{
    [HideInInspector] public ObjectColor pickupColor;
    Material myMaterial;
    EffectManager EM;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<MeshRenderer>().material;
        EM = EffectManager.instance;

       int colorNumber = Random.Range(1, 4); //Can only produce 1-3

        switch (colorNumber)
        {
            case 1:

                //Blue
                pickupColor = ObjectColor.Blue;
                EM.ChangeStripedBallColor(myMaterial, ObjectColor.Blue, false);
                break;

            case 2:

                //Green
                pickupColor = ObjectColor.Green;
                EM.ChangeStripedBallColor(myMaterial, ObjectColor.Green, false);
                break;

            case 3:

                //Yellow
                pickupColor = ObjectColor.Yellow;
                EM.ChangeStripedBallColor(myMaterial, ObjectColor.Yellow, false);
                break;

            default:

                Debug.Log("Random.range in PickupColor on the pickups is out of bounds");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
