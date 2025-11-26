using UnityEngine;

public class RedColorDecorator : IShape
{
    private IShape wrapped;

    public RedColorDecorator(IShape wrapped)
    {
        this.wrapped = wrapped;
    }

    public GameObject CreateShape()
    {
        GameObject obj = wrapped.CreateShape();
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null && renderer.material != null)
        {
            renderer.material.color = Color.red;
        }
        return obj;
    }
}
