using Assignment2Engine;

namespace TestAssignment2;

public class TestTaxLogic
{
    [Test]
    public void TaxLogic_AcceptsValues_ReturnsCorrect()
    {
        //arange
        double[] incomeList = { 110000 };
        int[] parentList = { 65 };
        int[] childList = { 15, 17 };
        double expected = 8800d;
        
        //act
        double taxAmount = TaxLogic.ComputeTax(incomeList, parentList, childList);
        Console.WriteLine("Tax Amount: " + taxAmount);
        
        //assert
        Assert.AreEqual(expected,taxAmount);
    }
}