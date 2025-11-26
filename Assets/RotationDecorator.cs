using UnityEngine;

public class RotationDecorator : IActionButtonClick
{
    private IActionButtonClick wrapped;

    public RotationDecorator(IActionButtonClick wrapped)
    {
        this.wrapped = wrapped;
    }

    public GameObject Click(Vector3 position)
    {
        GameObject obj = wrapped.Click(position);
        obj.transform.Rotate(0f, 90f, 0f);
        return obj;
    }
}
