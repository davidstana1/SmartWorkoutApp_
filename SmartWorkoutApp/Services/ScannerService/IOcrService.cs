namespace SmartWorkoutApp.Services.ScannerService;

public interface IOcrService
{
    public string ExtractTextFromImage(byte[] imageBytes);

    public MrzData ExtractMrzData(string ocrText);
}