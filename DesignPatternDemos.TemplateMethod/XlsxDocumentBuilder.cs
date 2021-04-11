namespace DesignPatternDemos.TemplateMethod
{
    /// <summary>
    /// Сборщик документа xlsx
    /// </summary>
    public class XlsxDocumentBuilder : DocumentBuilder
    {
        ///<inheritdoc/>
        protected override void ApplyStyles()
        {
            // Применяет стили, возможные в рамках документа xlsx
        }

        ///<inheritdoc/>
        protected override void RenderToFile()
        {
            // Выгружает документ в xlsx
        }
    }
}