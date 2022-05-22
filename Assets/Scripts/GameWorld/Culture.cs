using UnityEngine;

namespace GameWorld
{
    [CreateAssetMenu(fileName = "New Culture", menuName = "Cultures/Culture")]
    public class Culture : ScriptableObject
    {
        public string[] rulerFirstNames;
        public string[] rulerLastNames;

        public string[] provinceNames;
    }
}
