using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{


    public GameObject screen1, screen2, panelSettings;
    public Image loadImage;
    public Text loadingText;

	[SerializeField] private  Slider volumeSlider;
	[SerializeField] private  Image volmeIcon;
	[SerializeField] private  Sprite volumeEnabledSprite, volumeDiisabledSprite;


    public void ButtonSettings()
    {
        panelSettings.SetActive(!panelSettings.activeSelf);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }

    public void ButtonStartLoad()
    {

        screen1.SetActive(false);
        screen2.SetActive(true);
        StartCoroutine(ShowAnimations());
    }

    private IEnumerator ShowAnimations()
    {
        loadingText.gameObject.PunchScale(new Vector3(0.3f, 0.3f, 0.0f), 1.0f, 0.0f);
        iTween.RotateBy(loadImage.gameObject, iTween.Hash("z", -360, "looptype", iTween.LoopType.loop, "speed", 50));
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(ShowAnimations());
    }

	public void ChangeVolume(){
		if (volumeSlider.value <= 0) {
			volmeIcon.sprite = volumeDiisabledSprite;
		} else {
			volmeIcon.sprite = volumeEnabledSprite;
		}
		AudioListener.volume = Mathf.Clamp(volumeSlider.value, 0f, 1f);
	} 
}