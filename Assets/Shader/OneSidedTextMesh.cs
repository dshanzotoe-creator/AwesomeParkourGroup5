using UnityEngine;

[RequireComponent(typeof(TextMesh))]
[RequireComponent(typeof(MeshRenderer))]
public class OneSidedTextMesh : MonoBehaviour
{
    [SerializeField] private Shader oneSidedShader;

    private TextMesh textMesh;
    private MeshRenderer meshRenderer;
    private Material textMaterial;

    private void Start()
    {
        textMesh = GetComponent<TextMesh>();
        meshRenderer = GetComponent<MeshRenderer>();

        if (textMesh.font == null)
        {
            Debug.LogError("TextMesh has no font assigned.");
            return;
        }

        if (oneSidedShader == null)
        {
            Debug.LogError("No one-sided shader assigned.");
            return;
        }

        // Create our own copy of the font's REAL material.
        textMaterial = new Material(textMesh.font.material);

        // Replace its shader.
        textMaterial.shader = oneSidedShader;

        // Keep Unity's generated font texture.
        textMaterial.mainTexture = textMesh.font.material.mainTexture;

        meshRenderer.material = textMaterial;
    }
}
