using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    public class Car
    {
        private IEngine engine;
        private string plate;
        public int MaxEngineTemp = 200;

        public Car(IEngine e, string p)
        {
            engine = e;
            plate = p;
        }

        public string GetPlate()
        {
            return plate;
        }

        public void Accelerate(int rpmToAdd)
        {
            int currentRpm = engine.GetRpm();
            currentRpm += rpmToAdd;
            engine.SetRpm(currentRpm);
        }

        public int GetSpeed()
        {
            return engine.GetRpm()/10;
        }

        public string GetStatus()
        {
            return engine.GetTemp().GetTemperature() <= MaxEngineTemp ? "ok" : "overheating";
        }
    }
}
