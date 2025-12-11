using UnityEngine;

public interface IShape
{
    public GameObject CreateShape();
}
public abstract class Decorator : IShape
{
    protected IShape _shape;
    public Decorator(IShape shape)
    {
        _shape = shape;
    }
    public virtual GameObject CreateShape()
    {
        return _shape.CreateShape();
    }
}
