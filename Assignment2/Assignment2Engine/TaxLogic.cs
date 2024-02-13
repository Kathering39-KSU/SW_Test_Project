namespace Assignment2Engine;

public class TaxLogic
{
    public static double ComputeTax(double[] incomeList, int[] parentList, int[] childList)
    {
        double taxAmount = 0.0;
        double incomeAmount = 0.0;
        // Calculate the income amount
        for (int i = 0; i < incomeList.Length; i++)
        {
            incomeAmount += incomeList[i];
        }

        // Calculate the basic tax
        if (incomeAmount <= 40000)
        {
            taxAmount = incomeAmount * 0.02;
        }
        else if (incomeAmount > 40000 && incomeAmount <= 80000)
        {
            taxAmount = 800 + incomeAmount * 0.07;
        }
        else if (incomeAmount > 80000 && incomeAmount <= 120000)
        {
            taxAmount = 800 + 2800 + incomeAmount * 0.12;
        }
        else if (incomeAmount > 120000)
        {
            taxAmount = 800 + 2800 + 4800 + incomeAmount * 0.17;
        }

        // Calculate the tax exemption from having children
        int taxExemption = 0;
        int numOfChild = childList.Length;
        while (numOfChild > 0)
        {
            if (childList[numOfChild - 1] < 18)
            {
                taxAmount -= 4000;
                taxExemption += 4000;
            }

            numOfChild--;
        }

        // Calculate the tax exemption from having parents
        for (int j = 0; j < parentList.Length; j++)
        {
            if (parentList[j] > 60)
            {
                taxAmount -= 2000;
                taxExemption += 2000;
            }
        }

        // The maximum tax exemption is 8000 each person
        if (taxExemption <= 8000)
        {
            if (taxAmount >= 0)
            {
                return taxAmount;
            }
            else
            {
                // i.e., taxAmount < 0
                return 0;
            }
        }
        else
        {
            // i.e., taxExemption > 8000
            taxAmount += (taxExemption - 8000);
            return taxAmount;
        }
    }
}