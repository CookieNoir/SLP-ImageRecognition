public class StepFunction : ActivationFunction
{
    public override float GetResult(float value)
    {
        return value >= 0f ? 1f : 0f;
    }
}