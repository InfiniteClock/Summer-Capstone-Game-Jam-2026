using UnityEngine;

public class SortingBox : MonoBehaviour
{
    [SerializeField] private SortingColor sortingColor;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out SortingObject obj))
        {
            if (obj.SortColor == sortingColor)
            {
                // Correct Sorting Container
                Debug.Log("Correct!");
                obj.isSorted = true;
                obj.Despawn();
            }
            else
            {
                // Wrong Sorting Container
                Debug.Log("Wrong!");
            }
        }
    }
}
