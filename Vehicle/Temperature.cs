namespace Vehicle
{
    public class Temperature
    {
        private int temperature;

        public Temperature(int t)
        {
            temperature = t;

        }

        public int GetTemperature()
        {
            return temperature;
        }

        void SetTemperature(int temp)
        {
            temperature = temp;
        }
    }
}