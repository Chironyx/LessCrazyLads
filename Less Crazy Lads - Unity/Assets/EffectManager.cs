using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Utility;

public class EffectManager : MonoBehaviour
{
    [HeaderAttribute("Player Colors")]

    [SerializeField] MeshRenderer playerMR;
    [HideInInspector] public ObjectColor currentPlayerColor;

    [HeaderAttribute("Blue")]

    [ColorUsageAttribute(true, true)]
    [SerializeField] Color blueStripesColor;
    [ColorUsageAttribute(true, true)]
    [SerializeField] Color blueExteriorMarbleColor;
    [ColorUsageAttribute(true, true)]
    [SerializeField] Color blueInnerMarbleColor;

    [HeaderAttribute("Green")]

    [ColorUsageAttribute(true, true)]
    [SerializeField] Color greenStripesColor;
    [ColorUsageAttribute(true, true)]
    [SerializeField] Color greenExteriorMarbleColor;
    [ColorUsageAttribute(true, true)]
    [SerializeField] Color greenInnerMarbleColor;

    [HeaderAttribute("Yellow")]

    [ColorUsageAttribute(true, true)]
    [SerializeField] Color yellowStripesColor;
    [ColorUsageAttribute(true, true)]
    [SerializeField] Color yellowExteriorMarbleColor;
    [ColorUsageAttribute(true, true)]
    [SerializeField] Color yellowInnerMarbleColor;

    [HeaderAttribute("Particle Gradients")]

    //Darn, color over lifetime in particles is read-only, as a quick fix I'll do a different object for each partcile

    [SerializeField] GameObject bluePlayerParticles;
    [SerializeField] GameObject greenPlayerParticles;
    [SerializeField] GameObject yellowPlayerParticles;

    [HeaderAttribute("Road Mesh Creator")]

    [SerializeField] PathCreation.Examples.RoadMeshCreator RMC;

    [HeaderAttribute("Road Decorations")]

    [SerializeField] Texture2D roadStars;
    [SerializeField] Texture2D roadCircles;
    [SerializeField] Texture2D roadCats;

    [HeaderAttribute("Road Sides")]

    [SerializeField] Texture2D normalSides;
    [SerializeField] Texture2D cutSides;
    [SerializeField] Texture2D CircleSides;



    #region Singleton

    public static EffectManager instance;

    private void Awake()
    {
        if (EffectManager.instance == null)
        {
            instance = this;
        } else
        {
            Debug.Log("Warning - 2 effect managers exist, destroying extras");
            Destroy(this);
        }
    }

    #endregion

    public void ChangeStripedBallColor(Material ballMaterial, ObjectColor newColor, bool isObjectThePlayer)
    {
        switch (newColor)
        {
            case ObjectColor.Blue:

                ballMaterial.SetColor("_StripeColor", blueStripesColor);
                ballMaterial.SetColor("_MarbleOutherColor", blueExteriorMarbleColor);
                ballMaterial.SetColor("_InnerMarbleColor", blueInnerMarbleColor);
                if (isObjectThePlayer)
                {
                    currentPlayerColor = ObjectColor.Blue;
                }

                break;

            case ObjectColor.Green:

                ballMaterial.SetColor("_StripeColor", greenStripesColor);
                ballMaterial.SetColor("_MarbleOutherColor", greenExteriorMarbleColor);
                ballMaterial.SetColor("_InnerMarbleColor", greenInnerMarbleColor);
                if (isObjectThePlayer)
                {
                    currentPlayerColor = ObjectColor.Green;
                }
                break;

            case ObjectColor.Yellow:

                ballMaterial.SetColor("_StripeColor", yellowStripesColor);
                ballMaterial.SetColor("_MarbleOutherColor", yellowExteriorMarbleColor);
                ballMaterial.SetColor("_InnerMarbleColor", yellowInnerMarbleColor);
                if (isObjectThePlayer)
                {
                    currentPlayerColor = ObjectColor.Yellow;
                }
                break;

            default:
                Debug.Log("Error - no object color in a ChangeColor() function or material isn't the striped-ball material.");

            break;
        }
    }

    public void spawnParticles(GameObject parentObject, ObjectColor particleColor)
    {
        //Worth to note that particles contain scripts that make them auto-destory when they're done playing.
       switch (particleColor) 
        {
            case ObjectColor.Blue:
                var newParticleBlue = Instantiate(bluePlayerParticles, parentObject.transform.position, Quaternion.identity);
                newParticleBlue.transform.parent = parentObject.transform;
                break;

            case ObjectColor.Green:

                var newParticleGreen = Instantiate(greenPlayerParticles, parentObject.transform.position, Quaternion.identity);
                newParticleGreen.transform.parent = parentObject.transform;
                break;

            case ObjectColor.Yellow:

                var newParticleYellow = Instantiate(yellowPlayerParticles, parentObject.transform.position, Quaternion.identity);
                newParticleYellow.transform.parent = parentObject.transform;
                break;
        }
    }

    public void changeRoadDecoration(Texture2D texture)
    {
        RMC.roadMaterial.SetTexture("_RoadDeco", texture);
    }

    public void changeSideDecoration(Texture2D texture)
    {
        RMC.roadMaterial.SetTexture("_RoadSides", texture);
    }

}

public enum ObjectColor
{
    Blue,
    Green,
    Yellow,
    none
}

public enum RoadDecoration
{
    Stars,
    Circles,
    Cats
}

public enum SidesDecoration
{
    Lines,
    Circles,
    Spikes
}
