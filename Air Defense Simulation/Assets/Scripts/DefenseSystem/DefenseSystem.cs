using UnityEngine;

public class DefenseSystem : MonoBehaviour
{
    public float detectionRadius = 20f;
    public Transform firePoint;

    private DefenseState currentState;
    public GameObject projectilePrefab;
    public Threat targetThreat;

    public LogSubject logSubject;
    public UdpLoggerSender udpLoggerSender;
    public FrameCapture frameCapture;
    void Start()
    {
        ChangeState(new ScanningState(this));

        udpLoggerSender = GetComponent<UdpLoggerSender>();
        
        logSubject = new LogSubject();
        var logger = FindObjectOfType<SimulationLogger>();
        logSubject.Register(logger);
        
        frameCapture = GetComponent<FrameCapture>();
    }

    void Update()
    {
        currentState?.OnUpdate();
    }

    public void ChangeState(DefenseState newState)
    {
        currentState?.OnExit();
        currentState = newState;
        currentState.OnEnter();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}