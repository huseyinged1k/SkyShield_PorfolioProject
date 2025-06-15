using UnityEngine;

public class EngageState : DefenseState
{
    float fireCooldown = 0f;

    public EngageState(DefenseSystem system) : base(system) { }

    public override void OnEnter() { }

    public override void OnUpdate()
    {
        if (system.targetThreat == null)
        {
            system.ChangeState(new ScanningState(system));
            return;
        }

        float dist = Vector3.Distance(system.transform.position, system.targetThreat.transform.position);
        if (dist > system.detectionRadius)
        {
            system.ChangeState(new ScanningState(system));
            return;
        }

        fireCooldown -= Time.deltaTime;
        if (fireCooldown <= 0f)
        {
            ProjectileFactory.SpawnProjectile(system.projectilePrefab, system.firePoint.position, system.targetThreat.transform);
            
            system.logSubject?.Notify($"Engaged {system.targetThreat.threatId} - {system.targetThreat.threatType}");
            system.udpLoggerSender.OnLogEvent($"Threat engaged: {system.targetThreat.threatId} - {system.targetThreat.threatType}");
            system.frameCapture.OnLogEvent($"Threat engaged: {system.targetThreat.threatId} - {system.targetThreat.threatType}");
            
            fireCooldown = 1.5f;
        }
    }

    public override void OnExit() { }
}