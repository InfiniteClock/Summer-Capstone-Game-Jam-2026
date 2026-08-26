using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField]
    private float initialCForce;
    [SerializeField]
    private float speedPercentIncrease;

    public float currentCForce;

    private void Start()
    {
        currentCForce = initialCForce;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out SortingObject obj))
        {
            if (obj.TryGetComponent(out Rigidbody rb))
            {
                rb.linearVelocity = Vector3.right * currentCForce;
                //rb.AddForce(Vector3.right * currentCForce, ForceMode.Force);
            }
            else Debug.LogError("Object: " + obj.name + " does NOT have a Rigidbody!");
        }
    }

    public void IncreaseConveyorForce()
    {
        currentCForce *= 1 + speedPercentIncrease;
    }
}
