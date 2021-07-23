using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimationManager : MonoBehaviour
{

    void CoinAnimationOver()
    {
        GetComponent<Animator>().SetBool("PlayCoinAnimation", false);
    }
}
