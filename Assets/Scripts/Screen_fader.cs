
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Screen_fader : MonoBehaviour
{
    [SerializeField][CanBeNull] private MovementController movementController;
    [SerializeField] private float speedA;
    private CameraController cameraController;
    private Image image;
    private Color colorIm;

    private void Start()
    {
        cameraController = FindAnyObjectByType<CameraController>();
        image = GetComponent<Image>();
        colorIm = image.color;

        ImageVisible();

    }


    private void ImageVisible()
    {
        if (cameraController != null)
        {
            cameraController.UnlockCamera(false);
            movementController.SetCanMove(false);
        }
        if (colorIm.a > 0f)
        {
            colorIm.a -= speedA;
            image.color = colorIm;
            Invoke("ImageVisible", 0.16f);
        }
        else
        {
            if (cameraController != null)
            {
                cameraController.UnlockCamera(true);
                movementController.SetCanMove(true);
            }
        }
    }

    public void ImageNoVisible()
    {
        if (cameraController != null)
        {
            cameraController.UnlockCamera(false);
            movementController.SetCanMove(false);
        }
        if (colorIm.a < 1f)
            {
                colorIm.a += speedA;
                image.color = colorIm;
                Invoke("ImageNoVisible", 0.16f);
            }
    }
}
