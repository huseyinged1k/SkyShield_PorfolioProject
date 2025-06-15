
using UnityEngine;

public class Threat : MonoBehaviour
{
    public string threatId;
    public string threatType;
    public float speed = 5f;
    private Transform target;
    
    private float distance;
    private float distanceThreshold;

    public void Initialize(string id, string type, Transform targetBase)
    {
        threatId = id;
        threatType = type;
        target = targetBase;
    }

    private void Start()
    {
        distanceThreshold = target.transform.localScale.x;
    }
    
    public float GetDistanceToTarget()
    {
        if (target == null) return 0f;
        return Vector3.Distance(transform.position, target.position);
    }
    
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            
            if (GetDistanceToTarget() <= distanceThreshold)
            {
                Destroy(gameObject);
            }
        }
    }
}