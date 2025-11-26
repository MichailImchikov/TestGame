using UnityEngine;

public class RedColorDecorator : IShape
{
    private IShape wrapped;

    public RedColorDecorator(IShape wrapped)
    {
        this.wrapped = wrapped;
    }

    public GameObject Click()
    {
        GameObject obj = wrapped.Click();
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null && renderer.material != null)
        {
            renderer.material.color = Color.red;
        }
        return obj;
    }
}
