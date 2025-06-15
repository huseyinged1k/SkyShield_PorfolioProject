public abstract class DefenseState
{
    protected DefenseSystem system;
    public DefenseState(DefenseSystem system) { this.system = system; }
    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();
}