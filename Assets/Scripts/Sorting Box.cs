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
                if (!obj.isSorted)
                {
                    // Correct Sorting Container
                    //Debug.Log("Correct!");
                    RuntimeManager.PlayOneShot(positiveSound, transform.position);
                    obj.isSorted = true;
                    obj.Despawn();
                    GameplayManager.UpdateScore(GameplayManager.Instance.sortCorrectScore, obj.transform.position);
                }
            }
            else
            {
                // Wrong Sorting Container
                //Debug.Log("Wrong!");
                RuntimeManager.PlayOneShot(negativeSound, transform.position);
                GameplayManager.UpdateScore(GameplayManager.Instance.sortWrongScore, obj.transform.position);
            }
        }
    }
}
