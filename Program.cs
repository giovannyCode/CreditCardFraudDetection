namespace CreditCardFraudDetection
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("=== Credit Card Fraud Detection AutoML: Train → Save ZIP ===");

            // Save into a predictable location under this project's output
            var outputDir = Path.Combine(AppContext.BaseDirectory, "TrainedModels");
            Directory.CreateDirectory(outputDir);

            var zipPath = Path.Combine(outputDir, "CreditCardFraudDetectionModel.zip");

            // CSV is stored in the project root
            var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            var csvPath = Path.Combine(projectRoot, "credit_card_fraud_1000.csv");

            Console.WriteLine($"CSV: {csvPath}");
            Console.WriteLine($"ZIP: {zipPath}");

            if (!File.Exists(csvPath))
            {
                Console.WriteLine("CSV not found. Put lcredit_card_fraud_1000.csv in the project root.");
                return;
            }

            // This runs the AutoML-selected pipeline and SAVES the model to the zip path.
            FraudDetectionMLModel.Train(outputModelPath: zipPath, inputDataFilePath: csvPath);

            Console.WriteLine("Credit card fraud detection model ZIP created.");
        }
    }
}
