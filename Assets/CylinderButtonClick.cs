using UnityEngine;

public class CylinderButtonClick : IShape
{
    public GameObject Click()
    {
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.position += Vector3.up * 1.0f;
        ApplyColorShader(cylinder);
        return cylinder;
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
