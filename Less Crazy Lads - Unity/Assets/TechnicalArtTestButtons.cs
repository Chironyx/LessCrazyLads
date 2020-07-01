using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Utility;

public class TechnicalArtTestButtons : MonoBehaviour
{
    [Header("Change Player Material")]
    [SerializeField] MeshRenderer playerMR;
    [SerializeField] Material shaderMaterial;
    [SerializeField] Material simpleMaterial;
    bool playerMatIsSimple;

    [Header("Change Road Material")]
    [SerializeField] PathCreation.Examples.RoadMeshCreator RoadMeshCreator;
    [SerializeField] Material roadShaderMaterial;
    [SerializeField] Material roadSimpleMaterial;
    bool roadMatIsSimple;

    private void Start()
    {
        playerMatIsSimple = false;
        roadMatIsSimple = false;
    }

    public void ChangePlayerMaterial()
    {
        if (playerMatIsSimple)
        {

            playerMR.material = shaderMaterial;
            playerMatIsSimple = false;

        } 
        else
        {

            playerMR.material = simpleMaterial;
            playerMatIsSimple = true;

        }
    }

    public void ChangeRoadMaterial()
    {
        if (roadMatIsSimple)
        {

            RoadMeshCreator.roadMaterial = roadShaderMaterial;
            RoadMeshCreator.TriggerUpdate();
            roadMatIsSimple = false;

        }
        else
        {

            RoadMeshCreator.roadMaterial = roadSimpleMaterial;
            RoadMeshCreator.TriggerUpdate();
            roadMatIsSimple = true;

        }
    }


}
