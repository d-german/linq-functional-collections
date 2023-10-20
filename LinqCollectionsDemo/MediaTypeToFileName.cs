using System.Collections.Immutable;
using System.Net.Mime;

namespace LinqCollectionsDemo;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable  ConvertIfStatementToSwitchExpression
// ReSharper disable  ConvertIfStatementToSwitchStatement
// ReSharper disable ConvertSwitchStatementToSwitchExpression
public static class MediaTypeToFileName
{
    public const string Dicom = "application/vnd.hyland.nilread.apiviewer+dicom";
    public const string Excel = "application/vnd.ms-excel";
    public const string Html = MediaTypeNames.Text.Html;
    public const string MultipartForm = "multipart/form-data";
    public const string Pdf = MediaTypeNames.Application.Pdf;
    public const string Word = "application/msword";

    public const string DefaultFileName = "Undefined.png";
    public const string DicomStudyFileName = "DICOMStudy.png";
    public const string MsExcelFileName = "MsExcel.png";
    public const string HtmlFileName = "HTML.png";
    public const string ElectronicFormFileName = "ElectronicForm.png";
    public const string PdfFileName = "Pdf.png";
    public const string MsWordFileName = "MsWord.png";

    private static readonly IImmutableDictionary<string, string> ToFileName = new Dictionary<string, string>
    {
        [Dicom] = DicomStudyFileName,
        [Excel] = MsExcelFileName,
        [Html] = HtmlFileName,
        [MultipartForm] = ElectronicFormFileName,
        [Pdf] = PdfFileName,
        [Word] = MsWordFileName
    }.ToImmutableDictionary();

    /// <summary>
    /// Retrieves the file name associated with a given media type using a declarative approach.
    /// </summary>
    /// <param name="mediaType">The media type for which to retrieve the file name.</param>
    /// <returns>
    /// The file name associated with the specified media type. 
    /// If the media type is not recognized, returns the default file name.
    /// </returns>
    /// <remarks>
    /// This method utilizes a dictionary lookup to declaratively map media types to file names.
    /// </remarks>
    public static string GetFileNameDeclarative(string mediaType) => ToFileName.ContainsKey(mediaType) ? ToFileName[mediaType] : DefaultFileName;

    /// <summary>
    /// Retrieves the file name associated with a given media type using an imperative approach with a switch statement.
    /// </summary>
    /// <param name="mediaType">The media type for which to retrieve the file name.</param>
    /// <returns>
    /// The file name associated with the specified media type.
    /// If the media type is not recognized, returns the default file name.
    /// </returns>
    /// <remarks>
    /// This method uses a switch statement to map media types to file names imperatively,
    /// demonstrating a structured control flow mechanism for this mapping task.
    /// </remarks>
    public static string GetFileNameImperativeSwitchStatement(string mediaType)
    {
        switch (mediaType)
        {
            case Dicom:
                return DicomStudyFileName;
            case Excel:
                return MsExcelFileName;
            case Html:
                return HtmlFileName;
            case MultipartForm:
                return ElectronicFormFileName;
            case PdfFileName:
                return PdfFileName;
            case Word:
                return MsWordFileName;
            default:
                return DefaultFileName;
        }
    }

    public static string GetFileNameImperativeMultipleIf(string mediaType)
    {
        if (mediaType == Dicom)
            return DicomStudyFileName;
        if (mediaType == Excel)
            return MsExcelFileName;
        if (mediaType == Html)
            return HtmlFileName;
        if (mediaType == MultipartForm)
            return ElectronicFormFileName;
        if (mediaType == PdfFileName)
            return PdfFileName;
        if (mediaType == Word)
            return MsWordFileName;
        return DefaultFileName;
    }

    public static string GetFileNameSwitchExpression(string mediaType)
    {
        // Might prefer this to the dictionary if only using the dictionary in one place
        // Beginning with C# 8.0, you can use the switch expression
        return mediaType switch
        {
            Dicom => DicomStudyFileName,
            Excel => MsExcelFileName,
            Html => HtmlFileName,
            MultipartForm => ElectronicFormFileName,
            PdfFileName => PdfFileName,
            Word => MsWordFileName,
            _ => DefaultFileName
        };
    }

    /// <summary>
    /// Retrieves the file name associated with a given media type using a declarative approach without a default fallback.
    /// </summary>
    /// <param name="mediaType">The media type for which to retrieve the file name.</param>
    /// <returns>
    /// The file name associated with the specified media type.
    /// </returns>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when the specified media type is not recognized.
    /// </exception>
    /// <remarks>
    /// This method utilizes a dictionary lookup to declaratively map media types to file names.
    /// Unlike the GetFileNameDeclarative method, this method does not provide a default file name 
    /// and will throw a KeyNotFoundException if the media type is not found in the dictionary.
    /// </remarks>
    public static string GetFileNameDeclarativeNoDefault(string mediaType) => ToFileName[mediaType];
}