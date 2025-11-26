using UnityEngine;

public class CubeButtonClick : IActionButtonClick
{
    public GameObject Click(Vector3 position)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        position.y += 0.5f;
        cube.transform.position = position;
        ApplyColorShader(cube);
        return cube;
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
