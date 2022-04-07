using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour
{
    public GameObject CardPF;
    public List<GameObject> locations;

    void Start()
    {
        locations = CurrentGameInfo.CUR_GAME.cardObjLocations;
        //will need to get locations at which cards can be placed
    }

    public void createCard(string card, int locationNumber)
    {
        GameObject cardObject = Instantiate(CardPF, new Vector3(0, 0, 0), transform.rotation);
        PhysicalCard props = cardObject.GetComponent<PhysicalCard>();
        props.setCard(card.Substring(0, 1), card.Substring(1));
        cardObject.transform.SetParent(locations[locationNumber+1].transform, false);
    }
}
