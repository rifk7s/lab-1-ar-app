using TMPro;
using UnityEngine;

/// <summary>
/// Shows one model at a time from a list and updates a name label.
/// Attach to the ModelRoot GameObject (the parent of all your models).
/// </summary>
public class ModelSwitcher : MonoBehaviour
{
    [Tooltip("Drag your model GameObjects here, in the order you want to cycle through them.")]
    [SerializeField] private GameObject[] models;

    [Tooltip("Optional: a TextMeshPro label that shows the current model's name.")]
    [SerializeField] private TMP_Text nameLabel;

    private int current;

    private void Start()
    {
        Show(0);
    }

    // Called by the Next button (On Click event).
    public void Next()
    {
        if (models == null || models.Length == 0) return;
        Show((current + 1) % models.Length);
    }

    // Called by the Previous button (On Click event).
    public void Previous()
    {
        if (models == null || models.Length == 0) return;
        Show((current - 1 + models.Length) % models.Length);
    }

    private void Show(int index)
    {
        if (models == null || models.Length == 0) return;

        current = index;
        for (int i = 0; i < models.Length; i++)
        {
            if (models[i] != null)
                models[i].SetActive(i == current);
        }

        if (nameLabel != null && models[current] != null)
            nameLabel.text = $"{models[current].name}  ({current + 1}/{models.Length})";
    }
}