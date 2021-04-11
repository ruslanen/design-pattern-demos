namespace DesignPatternDemos.TemplateMethod
{
    /// <summary>
    /// Демонстрирует пример паттерна "Шаблонный метод", в котором шаги логики алгоритма вынесены в
    /// отдельный метод с определением реализаций общих методов, а конкретные методы алгоритма сбора документа
    /// позволено определить в субклассах.
    /// Является высокоуровневым компонентом.
    /// Клиенты должны зависеть от абстракций в виде ApplyStyles и RenderToFile.
    /// При этом вызов из компонентов низкого уровня методов: LoadDataInMemory или CalculateAggregates не запрещен, но суть
    /// в том, чтобы избежать циклических зависимостей. 
    /// </summary>
    public abstract class DocumentBuilder
    {
        /// <summary>
        /// Применить стили к отчету
        /// </summary>
        protected abstract void ApplyStyles();

        /// <summary>
        /// Отрисовать документ в необходимом типе файла
        /// </summary>
        protected abstract void RenderToFile();
        
        /// <summary>
        /// Собрать документ
        /// </summary>
        public void Build()
        {
            OnBeforeBuild();

            LoadDataInMemory();
            CalculateAggregates();
            ApplyStyles();
            RenderToFile();
            
            OnAfterBuild();
        }

        /// <summary>
        /// Загрузить данные документа в память
        /// </summary>
        protected void LoadDataInMemory()
        {
            // Общая логика по загрузке данных для документа в память
        }

        /// <summary>
        /// Рассчитать агрегаты в документе
        /// </summary>
        protected void CalculateAggregates()
        {
            // Общая логика по расчету агрегатов в документе
        }

        /// <summary>
        /// Метод "перехватчик", который объявляется в абстрактном классе и дающий возможность
        /// субклассам подключаться к алгоритму в разных точках.
        /// Используются для необязательных частей алгоритма.
        /// Вызывается перед сборкой документа.
        /// </summary>
        protected virtual void OnBeforeBuild()
        {
        }
        
        /// <summary>
        /// Вызывается после сборки документа.
        /// </summary>
        protected virtual void OnAfterBuild()
        {
        }
    }
}