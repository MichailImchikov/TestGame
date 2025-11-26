using UnityEngine;

public class RotationDecorator : IShape
{
    private IShape wrapped;

    public RotationDecorator(IShape wrapped)
    {
        this.wrapped = wrapped;
    }

    public GameObject Click()
    {
        GameObject obj = wrapped.Click();
        obj.transform.Rotate(0f, 90f, 0f);
        return obj;
    }
}
