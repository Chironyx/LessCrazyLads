using UnityEngine;

public class PlayerTriggerManager : MonoBehaviour
{

    [SerializeField] private int pickUpPoints;
    [SerializeField] private ObstacleSpawner obstacleSpawner;
    [SerializeField] private GameObject joystick;


    //Stuff for changing color after pickup

    EffectManager EM;
    Material myMaterial;

    private void Start()
    {
        EM = EffectManager.instance;
        myMaterial = GetComponent<MeshRenderer>().material;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obsticale"))
        {
            //game over
            UiManager.uiManager.GameOverUIState(true);
            UiManager.uiManager.UpdateGameOverScoreUi();
            UiManager.uiManager.CheckForHighscore();
            UiManager.uiManager.SetTime(0);
            joystick.SetActive(false);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("PickUp"))
        {

            //Apply new color
            ObjectColor colorOfThisPickup = other.GetComponent<PickupColor>().pickupColor;
            EM.ChangeStripedBallColor(myMaterial, colorOfThisPickup, true);
            EM.currentPlayerColor = colorOfThisPickup;
            EM.spawnParticles(gameObject, colorOfThisPickup);

            //Collect points

            UiManager.uiManager.AddToScore(pickUpPoints);
            Destroy(other.gameObject);
            //point up
        }

        if (other.CompareTag("CreateGroup1"))
        {
            obstacleSpawner.ResetDstValue();
            Debug.LogError("CreateGroup1");
            obstacleSpawner.SetSpawnerState(SpawnerState.createGroup1);
        }

        if (other.CompareTag("CreateGroup2"))
        {
            Debug.LogError("CreateGroup2");
            obstacleSpawner.SetSpawnerState(SpawnerState.createGroup2);
        }

        if (other.CompareTag("DestroyGroup1"))
        {
            Debug.LogError("DestroyGroup1");
            obstacleSpawner.SetSpawnerState(SpawnerState.destroyGroup1);
        }

        if (other.CompareTag("DestroyGroup2"))
        {
            Debug.LogError("DestroyGroup2");
            obstacleSpawner.SetSpawnerState(SpawnerState.destroyGroup2);
        }
    }

}
