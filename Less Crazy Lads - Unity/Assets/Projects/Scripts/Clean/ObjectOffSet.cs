using UnityEngine;

public class ObjectOffSet : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private float disFromPlatfurm = 0.3f;
    private RaycastHit _hitinfo;
    private Ray _ray;

    private void Start()
	{
        OffSet();
	}
    //fix the position of the object
    private void OffSet()
    {
        _ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(_ray, out _hitinfo, layer))
        {
            transform.position = new Vector3(transform.position.x, _hitinfo.point.y, transform.position.z) + new Vector3(0, disFromPlatfurm, 0);
            transform.rotation = Quaternion.FromToRotation(Vector3.up, _hitinfo.normal);
        }
    }
}
