using UnityEngine;

public class ThreatManager : MonoBehaviour
{
    public GameObject threatPrefab;
    public Transform targetBase;
    public float spawnInterval = 3f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnThreat();
            timer = 0f;
        }
    }

    void SpawnThreat()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-50f, 50f), 20f, Random.Range(30f, 50f));
        GameObject threatObj = Instantiate(threatPrefab, spawnPos, Quaternion.identity);
        var threat = threatObj.GetComponent<Threat>();
        string id = System.Guid.NewGuid().ToString();
        string type = Random.value > 0.5f ? "Drone" : "Missile";
        threat.Initialize(id, type, targetBase);
    }
}