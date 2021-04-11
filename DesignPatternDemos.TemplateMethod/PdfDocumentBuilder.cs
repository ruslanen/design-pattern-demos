namespace DesignPatternDemos.TemplateMethod
{
    /// <summary>
    /// Сборщик документа pdf
    /// </summary>
    public class PdfDocumentBuilder : DocumentBuilder
    {
        ///<inheritdoc/>
        protected override void ApplyStyles()
        {
            // Применяет стили, возможные в рамках документа pdf
        }

        ///<inheritdoc/>
        protected override void RenderToFile()
        {
            // Выгружает документ в pdf
        }
    }
}