using Random = UnityEngine.Random;

namespace SWeetJelly
{
    public static class RandomUtils
    {
        public static bool TrueFalse()
        {
            return Random.Range(0, 2) == 0;
        }

        public static int Range(DuoInt duoInt)
        {
            return Random.Range(duoInt.firstValue, duoInt.secondValue);
        }

        public static float Range(DuoFloat duoFloat)
        {
            return Random.Range(duoFloat.firstValue, duoFloat.secondValue);
        }
    }
}