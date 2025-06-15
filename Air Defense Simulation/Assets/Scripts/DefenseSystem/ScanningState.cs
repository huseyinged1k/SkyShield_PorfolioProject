using System.Linq;
using UnityEngine;

public class ScanningState : DefenseState
{
    public ScanningState(DefenseSystem system) : base(system) { }

    public override void OnEnter() { }

    public override void OnUpdate()
    {
        var threats = GameObject.FindObjectsOfType<Threat>();
        foreach (var t in threats)
        {
            float distance = Vector3.Distance(system.transform.position, t.transform.position);
            if (distance <= system.detectionRadius)
            {
                system.targetThreat = t;
                system.ChangeState(new EngageState(system));
                return;
            }
        }
    }

    public override void OnExit() { }
}