using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    public bool IsBlocking(RectTransform objToCheck)
    {
        RectTransform current = GetComponent<RectTransform>();

        float currLeft = current.position.x - current.rect.width / 2;
        float currRight = current.position.x + current.rect.width / 2;
        float checkLeft = objToCheck.position.x - objToCheck.rect.width / 2;
        float checkRight = objToCheck.position.x + objToCheck.rect.width / 2;

        float currTop = current.position.y - current.rect.height / 2;
        float currBottom = current.position.y + current.rect.height / 2;
        float checkTop = objToCheck.position.y - objToCheck.rect.height / 2;
        float checkBottom = objToCheck.position.y + objToCheck.rect.height / 2;

        if (((checkLeft < currRight && checkLeft > currLeft) || (checkRight < currRight && checkRight > currLeft)) &&
            ((checkTop < currBottom && checkTop > currTop) || (checkBottom < currBottom && checkBottom > currTop)))
        {
            return true;
        }
        return false;
    }
}
