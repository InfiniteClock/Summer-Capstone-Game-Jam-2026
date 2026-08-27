using UnityEngine;
using FMODUnity;

public class SortingBox : MonoBehaviour
{
    [SerializeField] private SortingColor sortingColor;
    [SerializeField] private EventReference positiveSound;
    [SerializeField] private EventReference negativeSound;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out SortingObject obj))
        {
            if (obj.SortColor == sortingColor)
            {
                // Correct Sorting Container
                Debug.Log("Correct!");
                RuntimeManager.PlayOneShot(positiveSound, transform.position);
                obj.isSorted = true;
                obj.Despawn();
            }
            else
            {
                // Wrong Sorting Container
                Debug.Log("Wrong!");
                RuntimeManager.PlayOneShot(negativeSound, transform.position);
            }
        }
    }
}
