using UnityEngine;

public class ObservablesBinderMB : MonoBehaviour
{
    private void Start()
    {
        var player = FindObjectOfType<PlayerMB>();
        if (player == null)
        {
            Debug.LogError("PlayerMB not found in the scene.");
            return;
        }

        var observables = FindObjectsOfType<AObservable>();
        foreach (var observable in observables)
        {
            (observable)?.AddObserver(player);
        }
    }
}
