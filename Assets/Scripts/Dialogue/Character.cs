using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue 
{
    [CreateAssetMenu(menuName = "Character", fileName = "Character")]
    public class Character : ScriptableObject
    {
        public Sprite Portrait;
        public string Name;
    }
}