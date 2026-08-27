using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField]
    private float initialCForce;

    public float currentCForce;

    [SerializeField] private float beltSpeed = 1f;
    [SerializeField] private Animator animator;

    private void Start()
    {
        currentCForce = initialCForce;
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Belt_Speed", beltSpeed);
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

    public void IncreaseConveyorForce(float percent)
    {
        currentCForce *= 1 + percent;
        beltSpeed *= 1 + percent;
    }
}
