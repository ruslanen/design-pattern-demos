namespace DesignPatternDemos.Builder
{
    /// <summary>
    /// Директор знает, в какой последовательности нужно заставлять работать строителя, чтобы получить ту или иную версию дома.
    /// Отдельный класс директора не является строго обязательным. Можно вызывать методы строителя и напрямую из клиентского кода.
    /// Тем не менее, директор полезен, если есть несколько способов конструирования объектов, отличающихся порядком и наличием шагов конструирования.
    /// </summary>
    public class HouseConstructDirector
    {
        public void BuildStandardHouse(IHouseBuilder houseBuilder, bool withGarage)
        {
            houseBuilder.BuildFacade();
            houseBuilder.BuildWalls();
            houseBuilder.BuildWindows();
            houseBuilder.BuildFence();

            if (withGarage)
            {
                houseBuilder.BuildGarage();              
            }
        }
    }
}