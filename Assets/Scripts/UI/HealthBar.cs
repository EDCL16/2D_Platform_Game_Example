#region

using UnityEngine;
using UnityEngine.UI;

#endregion

public class HealthBar : MonoBehaviour
{
    #region Private Variables

    [SerializeField]
    private Slider slider;

    #endregion

    #region Public Methods


    public void SetCurrent(int value)
    {
        slider.value = value;
    }

    public void SetMax(int value)
    {
        slider.maxValue = value;
    }
    #endregion
}