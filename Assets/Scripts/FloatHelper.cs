public static class FloatHelper
{
    public static float[] GetDifference(float[] vector1, float[] vector2)
    {
        if (vector1.Length == vector2.Length)
        {
            float[] result = new float[vector1.Length];
            for (int i = 0; i < result.Length; ++i)
            {
                result[i] = vector1[i] - vector2[i];
            }
            return result;
        }
        else return null;
    }
}