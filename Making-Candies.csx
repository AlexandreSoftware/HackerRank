

public static long minimumPasses(long startingMachines, long startingWorkers, long newHireCost, long productionMeta)
{
    long currentStep,
     currentCandy = 0,
     currentPasses = 0,
     currentRun = long.MaxValue;

    while (currentCandy < productionMeta)
    {
        currentStep = (startingMachines > long.MaxValue / startingWorkers) ? 0 : (newHireCost - currentCandy) / (startingMachines * startingWorkers);

        if (currentStep <= 0)
        {
            long toHire = currentCandy / newHireCost;

            if (startingMachines >= startingWorkers + toHire)
            {
                startingWorkers += toHire;
            }
            else if (startingWorkers >= startingMachines + toHire)
            {
                startingMachines += toHire;
            }
            else
            {
                long total = startingMachines + startingWorkers + toHire;
                startingMachines = total / 2;
                startingWorkers = total - startingMachines;
            }

            currentCandy %= newHireCost;
            currentStep = 1;
        }

        currentPasses += currentStep;

        if (currentStep * startingMachines > long.MaxValue / startingWorkers)
        {
            currentCandy = long.MaxValue;
        }
        else
        {
            currentCandy += currentStep * startingMachines * startingWorkers;
            currentRun = Math.Min(currentRun, (long)(currentPasses + Math.Ceiling((productionMeta - currentCandy) / (startingMachines * startingWorkers * 1.0))));
        }
    }

    return Math.Min(currentPasses, currentRun);
}