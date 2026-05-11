using UnityEngine;

public class DestroyAfterXSeconds : MonoBehaviour
{
    [SerializeField]
    float lifeTime  = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
