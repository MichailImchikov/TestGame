using UnityEngine;

public class SphereButtonClick : IActionButtonClick
{
    public GameObject Click(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        position.y += 0.5f;
        sphere.transform.position = position;
        ApplyColorShader(sphere);
        return sphere;
    }

    private void ApplyColorShader(GameObject obj)
    {
        Shader shader = Shader.Find("Universal Render Pipeline/Lit");
        if (shader != null)
        {
            Material material = new Material(shader);
            material.color = Color.white;
            obj.GetComponent<Renderer>().material = material;
        }
        else
        {
            Debug.LogWarning("Universal Render Pipeline/Lit not found, using Standard shader");
            Material material = new Material(Shader.Find("Standard"));
            material.color = Color.white;
            obj.GetComponent<Renderer>().material = material;
        }
    }
}
