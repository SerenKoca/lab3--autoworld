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
                descriptionText.text = "De Ford Model T was de eerste massaal geproduceerde auto van Ford en wordt vaak geprezen als de auto die de auto-industrie toegankelijk maakte voor de massa. Het had een topsnelheid van 72 km/u en een 1/4 mijl tijd van 32 seconden, wat voor die tijd behoorlijk snel was. De motor produceerde 22 pk en de lengte van de auto was 3,404 meter. De acceleratie van de Model T was vrij langzaam, met een tijd van 35 seconden om van 0 naar 45 mph te gaan, en de acceleratie van 0-60 mph is niet beschikbaar. De auto had een acceleratie van 0,57 m/s², wat vrij bescheiden was in vergelijking met moderne voertuigen.";
                carImage.material.mainTexture = car1Image; // Texture voor de eerste auto
                break;

            case 2:
                titleText.text = "Ford Model 40 / V8 (1933)";
                descriptionText.text = "De Ford Model 40 / V8, geïntroduceerd in 1933, was de eerste productieauto met een V8-motor van Ford. Dit model verbeterde de prestaties aanzienlijk ten opzichte van eerdere modellen. Het had een topsnelheid van 122 km/u en was uitgerust met een V8-motor die 65 pk produceerde. De lengte van het voertuig was 4,630 meter. De specificaties voor 0-45 mph en 0-60 mph zijn niet beschikbaar, maar de acceleratie van de Model 40 / V8 was sterk voor zijn tijd, met een versnelling van 1,34 m/s².o
                break;

            case 3:
                titleText.text = "Ford Mustang Mk1 (1965)";
                descriptionText.text = "De Ford Mustang Mk1, gelanceerd in 1965, is een iconisch model dat het sportwagensegment in de VS revolutioneerde. De Mustang Mk1 had een topsnelheid van 181 km/u en een 1/4 mijl tijd van 16,4 seconden. Het had een krachtige motor die 225 pk produceerde, en de lengte van de auto was 4,613 meter. De Mustang Mk1 was uitzonderlijk in zijn acceleratie van 0-45 mph en 0-60 mph, hoewel de exacte tijden niet beschikbaar zijn. De acceleratie van de Mustang Mk1 was 3,16 m/s², wat hem tot een van de snelste auto's van zijn tijd maakte.";
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
