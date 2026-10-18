using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch.Touch;
#endif

/// <summary>
/// One-finger drag rotates, two-finger pinch scales.
/// In the Editor: left-mouse drag rotates, mouse wheel scales.
/// Attach to the ModelRoot GameObject (the parent of all your models).
/// Works with both the new Input System and the legacy Input Manager.
/// </summary>
public class TouchManipulator : MonoBehaviour
{
    [Header("Rotation")]
    [Tooltip("Degrees of rotation per pixel dragged.")]
    [SerializeField] private float rotateSpeed = 0.3f;

    [Header("Scale (relative to the starting scale)")]
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 3f;
    [Tooltip("Scale change per mouse-wheel notch in the Editor.")]
    [SerializeField] private float scrollZoomStep = 0.1f;

    private Vector3 initialScale;
    private Quaternion initialRotation;
    private bool gestureStartedOnUI;
    private Vector2 lastMousePosition;

    private static readonly List<RaycastResult> uiHits = new List<RaycastResult>();

    private void Awake()
    {
        initialScale = transform.localScale;
        initialRotation = transform.localRotation;
    }

#if ENABLE_INPUT_SYSTEM
    private void OnEnable()  { EnhancedTouchSupport.Enable(); }
    private void OnDisable() { EnhancedTouchSupport.Disable(); }
#endif

    private void Update()
    {
        int count = TouchCount();

        if (count == 0)
        {
            HandleMouse();
            return;
        }

        // Ignore gestures that start on a button, so tapping "Next" does not spin the model.
        if (TouchBegan(0))
            gestureStartedOnUI = IsOverUI(TouchPosition(0));
        if (gestureStartedOnUI)
            return;

        if (count == 1)
        {
            Rotate(TouchDelta(0));
        }
        else
        {
            Vector2 p0 = TouchPosition(0), p1 = TouchPosition(1);
            Vector2 d0 = TouchDelta(0),    d1 = TouchDelta(1);

            float previousDistance = Vector2.Distance(p0 - d0, p1 - d1);
            float currentDistance  = Vector2.Distance(p0, p1);
            if (previousDistance > 1f)
                ApplyScale(currentDistance / previousDistance);
        }
    }

    // Called by the Reset button (On Click event).
    public void ResetView()
    {
        transform.localRotation = initialRotation;
        transform.localScale = initialScale;
    }

    private void Rotate(Vector2 delta)
    {
        // Horizontal drag: spin around the target's "up" axis, which is the normal of the printed image.
        transform.Rotate(0f, -delta.x * rotateSpeed, 0f, Space.Self);
        // Vertical drag: tilt around the horizontal axis, so the model can be turned toward the viewer.
        transform.Rotate(delta.y * rotateSpeed, 0f, 0f, Space.World);
    }

    private void ApplyScale(float factor)
    {
        float relative = transform.localScale.x / initialScale.x * factor;
        relative = Mathf.Clamp(relative, minScale, maxScale);
        transform.localScale = initialScale * relative;
    }

    private void HandleMouse()
    {
        if (!MouseAvailable()) return;

        Vector2 position = MousePosition();

        if (MousePressedThisFrame())
        {
            gestureStartedOnUI = IsOverUI(position);
            lastMousePosition = position;
        }

        if (MouseHeld() && !gestureStartedOnUI)
            Rotate(position - lastMousePosition);

        lastMousePosition = position;

        float scroll = MouseScroll();
        if (Mathf.Abs(scroll) > 0.01f && !IsOverUI(position))
            ApplyScale(1f + Mathf.Sign(scroll) * scrollZoomStep);
    }

    private static bool IsOverUI(Vector2 screenPosition)
    {
        if (EventSystem.current == null) return false;
        var data = new PointerEventData(EventSystem.current) { position = screenPosition };
        uiHits.Clear();
        EventSystem.current.RaycastAll(data, uiHits);
        return uiHits.Count > 0;
    }

    // ---------- Input wrappers: one version per input system ----------
#if ENABLE_INPUT_SYSTEM
    private static int TouchCount() => ETouch.activeTouches.Count;
    private static Vector2 TouchPosition(int i) => ETouch.activeTouches[i].screenPosition;
    private static Vector2 TouchDelta(int i) => ETouch.activeTouches[i].delta;
    private static bool TouchBegan(int i) =>
        ETouch.activeTouches[i].phase == UnityEngine.InputSystem.TouchPhase.Began;

    private static bool MouseAvailable() => Mouse.current != null;
    private static Vector2 MousePosition() => Mouse.current.position.ReadValue();
    private static bool MousePressedThisFrame() => Mouse.current.leftButton.wasPressedThisFrame;
    private static bool MouseHeld() => Mouse.current.leftButton.isPressed;
    private static float MouseScroll() => Mouse.current.scroll.ReadValue().y;
#else
    private static int TouchCount() => Input.touchCount;
    private static Vector2 TouchPosition(int i) => Input.GetTouch(i).position;
    private static Vector2 TouchDelta(int i) => Input.GetTouch(i).deltaPosition;
    private static bool TouchBegan(int i) =>
        Input.GetTouch(i).phase == UnityEngine.TouchPhase.Began;

    private static bool MouseAvailable() => Input.mousePresent;
    private static Vector2 MousePosition() => Input.mousePosition;
    private static bool MousePressedThisFrame() => Input.GetMouseButtonDown(0);
    private static bool MouseHeld() => Input.GetMouseButton(0);
    private static float MouseScroll() => Input.mouseScrollDelta.y;
#endif
}