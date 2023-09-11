namespace montecarlo;

internal class Program
{
    public static void Main(string[] args)
    {
        var expectedDecimalPlace = 2;
        var numberOfExperiment = 10;
        var resultList = new List<double>();
        var isDone = false;
        var numberOfPoint = 50000;
        
        
        while (!isDone)
        {
            for (var e = 0; e < numberOfExperiment; e++)
            {
                var estimatePi = MonteCarlo(numberOfPoint);
                
                resultList.Add(Math.Round(estimatePi, expectedDecimalPlace));
            }
        
            var isAllEqual = resultList.TrueForAll(x => x.Equals(resultList.First()));
            
            if (isAllEqual)
            {
                isDone = true;
            }
            
            Console.WriteLine(String.Join(", ", resultList));
            Console.WriteLine("number of point use " + numberOfPoint.ToString());
            
            numberOfPoint++;
            resultList = new List<double>();
        }
    }

    public static double MonteCarlo(int numberOfPoint)
    {
        var rnd = new Random();
        var counter = 0;
                
        for (var p = 0; p < numberOfPoint; p++)
        {
            var x = rnd.NextDouble();
            var y = rnd.NextDouble();

            var s = Math.Sqrt((y * y) + (x * x));

            if (s <= 1.0)
            {
                counter++;
            }
        }
                
        return (Convert.ToDouble(counter) / Convert.ToDouble(numberOfPoint)) * 4.00;
    }
}