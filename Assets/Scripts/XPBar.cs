using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class XPBar : MonoBehaviour
{
    public Image xpBarImage;
    public PointCollection Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // calc fill amount
        float maxExperiencePoints = 200;
        float currentExperienePoints = Player.experiencePoints;
        //fill amount
        float fillAmount = Mathf.Clamp(currentExperienePoints / maxExperiencePoints, 0, 1);
      //  xpBarImage.fillAmount = fillAmount;
    }
}
