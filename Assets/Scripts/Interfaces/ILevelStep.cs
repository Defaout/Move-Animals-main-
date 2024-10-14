using System;

public interface ILevelStep
{
    string StartText { get; set; }
    event Action<ILevelStep> OnStepStart;
    event Action<ILevelStep> OnStepEnd;
    void StartStep();
    void FinishStep();
    float GetProgressStep();
}