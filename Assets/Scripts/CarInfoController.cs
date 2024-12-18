using UnityEngine;
using TMPro; // Vergeet niet TextMeshPro te importeren
using UnityEngine.UI; // Voor de Image-component

public class CarInfoController : MonoBehaviour
{
    // Referentie naar het informatiescherm
    public GameObject infoPanel;

    // UI-elementen voor TextMeshPro
    public TMP_Text titleText;
    public TMP_Text descriptionText;

    // Referentie naar de car image (Image-component)
    public Image carImage;

    // Referenties naar de afbeeldingen (textures) voor de verschillende auto's
    public Texture car1Image;  // Eerste auto afbeelding
    public Texture car2Image;  // Tweede auto afbeelding
    public Texture car3Image;  // Derde auto afbeelding

    // Toon het informatiescherm met de juiste inhoud
    public void ShowCarInfo(int carID)
    {
        infoPanel.SetActive(true);

        // Zorg ervoor dat de material instanties uniek zijn
        carImage.material = new Material(carImage.material);

        switch (carID)
        {
            case 1:
                titleText.text = "Ford Model T (1908)";
                descriptionText.text = "De Ford Model T was de eerste massaal geproduceerde auto van Ford...";
                carImage.material.mainTexture = car1Image; // Texture voor de eerste auto
                break;

            case 2:
                titleText.text = "Ford Model 40 / V8 (1933)";
                descriptionText.text = "De Ford Model 40 / V8, geïntroduceerd in 1933...";
                carImage.material.mainTexture = car2Image; // Texture voor de tweede auto
                break;

            case 3:
                titleText.text = "Ford Mustang Mk1 (1965)";
                descriptionText.text = "De Ford Mustang Mk1, gelanceerd in 1965...";
                carImage.material.mainTexture = car3Image; // Texture voor de derde auto
                break;
        }
    }

    // Verberg het informatiescherm
    public void CloseInfo()
    {
        infoPanel.SetActive(false);
    }
}
