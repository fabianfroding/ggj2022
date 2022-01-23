using UnityEngine;

public class PostProcess : MonoBehaviour
{
    public Material material;
    public Shader shader;

    void Start()
    {
        material = new Material(shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}
