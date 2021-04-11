namespace DesignPatternDemos.TemplateMethod
{
    /// <summary>
    /// Сборщик документа txt
    /// </summary>
    public class TxtDocumentBuilder : DocumentBuilder
    {
        ///<inheritdoc/>
        protected override void ApplyStyles()
        {
            // Применяет стили, возможные в рамках документа txt
        }

        ///<inheritdoc/>
        protected override void RenderToFile()
        {
            // Выгружает документ в txt
        }
    }
}