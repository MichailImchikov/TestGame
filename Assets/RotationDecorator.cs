using UnityEngine;

public class RotationDecorator : IShape
{
    private IShape wrapped;

    public RotationDecorator(IShape wrapped)
    {
        this.wrapped = wrapped;
    }

    public GameObject CreateShape()
    {
        GameObject obj = wrapped.CreateShape();
        obj.transform.Rotate(0f, 90f, 0f);
        return obj;
    }
}
