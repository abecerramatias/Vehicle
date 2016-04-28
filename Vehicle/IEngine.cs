namespace Vehicle
{
    public interface IEngine
    {
        int GetRpm();
        void SetRpm(int rpmToAdd);
        Temperature GetTemp();
    }
}