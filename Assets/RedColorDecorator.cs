using UnityEngine;

public class RedColorDecorator : Decorator
{
    public RedColorDecorator(IShape shape) : base(shape)
    {
    }

    public override GameObject CreateShape()
    {
        GameObject obj = base.CreateShape();
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null && renderer.material != null)
        {
            renderer.material.color = Color.red;
        }
        return obj;
    }
}
