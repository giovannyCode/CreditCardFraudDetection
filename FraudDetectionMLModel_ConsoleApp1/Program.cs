
using Microsoft.ML;

namespace FraudDetectionMLModel_ConsoleApp1;

class Program
{
    
    static void Main()
    {
        MLContext _mlContext = new(seed: 42);
        ITransformer? _FraudDetectionModel;
        var modelsDir = Path.Combine(AppContext.BaseDirectory, "MLModels");
        var approvalPath = Path.Combine(modelsDir, "CreditCardFraudDetectionModel.zip");
         if (!File.Exists(approvalPath))
            throw new FileNotFoundException("Credit Card Fraud Detection model not found.", approvalPath);

        using (var stream = File.OpenRead(approvalPath))
        _FraudDetectionModel = _mlContext.Model.Load(stream, out _);

        TransactionInput sampleData = new TransactionInput()
        {
            TransactionId = 2F,
            TransactionAmount = 38.98F,
            HourOfDay = 19F,
            MerchantCategory = @"Grocery",
            EntryMode = @"Chip",
            Country = @"US",
            IsInternational = 0F,
            CardPresent = 1F,
            DaysSinceLastTransaction = 3.65F,
            TransactionCount24h = 4F,
            AvgAmount7d = 121.91F,
        };

        foreach (var property in typeof(TransactionInput).GetProperties())
        {
            Console.WriteLine($"{property.Name}: {property.GetValue(sampleData)}");
        }
        Console.WriteLine("Using model to make single prediction.\n\n");
        var engine = _mlContext.Model.CreatePredictionEngine<TransactionInput, FraudPrediction>(_FraudDetectionModel!);
        var prediction = engine.Predict(sampleData);
              
        Console.WriteLine($"{"Prediction:"}{(prediction.IsLikelyFraud?"this is fraud":"this is not fraud")}");
        Console.WriteLine($"Probability: {prediction.Probability}");
        Console.WriteLine($"Score: {prediction.Score}");
        Console.WriteLine(" =============== End of process, hit any key to finish ===============");
        Console.ReadKey();


    }

    }

