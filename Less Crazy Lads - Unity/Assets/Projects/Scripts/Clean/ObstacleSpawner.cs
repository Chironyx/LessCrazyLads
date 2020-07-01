
using UnityEngine;
using PathCreation;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] VarStorge varStorge;

    [SerializeField] private GameObject holderGroup1;
    [SerializeField] private GameObject holderGroup2;
    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private GameObject[] easyPatternArray;
    [SerializeField] private GameObject[] midPatternArray;
    [SerializeField] private GameObject[] hardPatternArray;

    private float _prsente = 0.5f;
    private float _dst;
    const float _minSpacing = .1f;
    private VertexPath _path;
    private SpawnerState _spawnerState = SpawnerState.createGroup1;

   private void Start()
     {
          _dst = varStorge.safeDisFromStart;
            _path = pathCreator.path;
        varStorge.spacingBtwObsticale = Mathf.Max(_minSpacing, varStorge.spacingBtwObsticale);  
      }
    private void Update()
      {
        switch (_spawnerState)
        {
            case SpawnerState.createGroup1:
                CreateGroup1();
                break;
            case SpawnerState.createGroup2:
                CreateGroup2();
                break;
            case SpawnerState.destroyGroup1:
                DestroyGroup1();
                break;
            case SpawnerState.destroyGroup2:
                DestroyGroup2();
                break;
        }
    }
    public void ResetDstValue()
    {
       _dst = 0;
    }
    public void SetSpawnerState(SpawnerState setSpawnerState)
    {
        _spawnerState = setSpawnerState;
    }

    //random the level pattern
    private void Randomiser(GameObject holder)
    {
        float easy = varStorge.easyPattern; // 10
        float mid = varStorge.easyPattern + varStorge.midPattern; // 30
        float hard = varStorge.midPattern + varStorge.hardPattern;  // 60

        float randomiser = Random.Range(0f, hard);

        if (randomiser <= easy)
        {
            //insance ez
            GameObject insacne = easyPatternArray[Random.Range(0, easyPatternArray.Length)];
            InstantiateTheRandom(insacne, holder);
        }
        else if (randomiser > easy && randomiser <= mid)
        {
            //insance mid
            GameObject insacne = midPatternArray[Random.Range(0, midPatternArray.Length)];
            InstantiateTheRandom(insacne, holder);
        }
        else if (randomiser > mid && randomiser <= hard)
        {
            //instace hard
            GameObject insacne = hardPatternArray[Random.Range(0, hardPatternArray.Length)];
            InstantiateTheRandom(insacne, holder);
        }
    }
    //create the random pattern
    private void InstantiateTheRandom(GameObject prefab,GameObject holder)
    {
        Vector3 point = _path.GetPointAtDistance(_dst);
        Quaternion rot = _path.GetRotationAtDistance(_dst);
        Instantiate(prefab, point + Vector3.up, rot, holder.transform);
        _dst += varStorge.spacingBtwObsticale;
    }
    //destroy one of the group
    private void DestroyObjects(GameObject holder)
    {
        int numChildren = holder.transform.childCount;
        for (int i = numChildren - 1; i >= 0; i--)
        {
            DestroyImmediate(holder.transform.GetChild(i).gameObject, false);
        }
    }
    private void CreateGroup1()
    {

        if (_dst <= _path.length * _prsente)
        {
            Randomiser(holderGroup1);
        }
    }
    private void CreateGroup2()
    {
        if (_dst <= _path.length)
        {
            Randomiser(holderGroup2);
        }
    }
    private void DestroyGroup1()
    {
        DestroyObjects(holderGroup1);
    }
    private void DestroyGroup2()
    {
        DestroyObjects(holderGroup2);
    }

}

public enum SpawnerState
{
    createGroup1,
    createGroup2,
    destroyGroup1,
    destroyGroup2
}
   


