using UnityEngine;

public class CylinderButtonClick : IActionButtonClick
{
    public GameObject Click(Vector3 position)
    {
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        position.y += 1.0f;
        cylinder.transform.position = position;
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
