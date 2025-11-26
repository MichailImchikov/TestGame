using UnityEngine;

public class RedColorDecorator : IActionButtonClick
{
    private IActionButtonClick wrapped;

    public RedColorDecorator(IActionButtonClick wrapped)
    {
        this.wrapped = wrapped;
    }

    public GameObject Click(Vector3 position)
    {
        GameObject obj = wrapped.Click(position);
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null && renderer.material != null)
        {
            renderer.material.color = Color.red;
        }
        return obj;
    }
}
