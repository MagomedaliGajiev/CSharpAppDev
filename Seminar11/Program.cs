namespace Seminar11
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        class Weather
        {
            WeatherInfo current;
            List<WeatherInfo> history;

            class WeatherInfo : IComparable<WeatherInfo> 
            {
                DateTime time;
                int teperature;
                int weathecode;
                double windspeed;
                int winddirection;

                public int CompareTo(WeatherInfo? other)
                {
                    throw new NotImplementedException();
                }
            }
        }

        
    }
}