using UnityEngine;

public class Indicator : MonoBehaviour
{
    public Transform IndicatorSource;
    public float IndicatorRange;
    public LayerMask mask;

    public GameObject IndicatorUI;

    private void Update()
    {
        Ray r = new Ray(IndicatorSource.position, IndicatorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, IndicatorRange, mask))
        {
            IndicatorUI.SetActive(true);
        }
        else
        {
            IndicatorUI.SetActive(false);
        }

    }
}
