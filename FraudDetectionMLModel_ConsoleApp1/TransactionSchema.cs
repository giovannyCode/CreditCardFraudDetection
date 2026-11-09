using Microsoft.ML;
using Microsoft.ML.Data;

namespace FraudDetectionMLModel_ConsoleApp1;

    public  class TransactionInput
    {
            [LoadColumn(0)]
            [ColumnName(@"TransactionId")]
            public float TransactionId { get; set; }

            [LoadColumn(1)]
            [ColumnName(@"TransactionAmount")]
            public float TransactionAmount { get; set; }

            [LoadColumn(2)]
            [ColumnName(@"HourOfDay")]
            public float HourOfDay { get; set; }

            [LoadColumn(3)]
            [ColumnName(@"MerchantCategory")]
            public string MerchantCategory { get; set; }

            [LoadColumn(4)]
            [ColumnName(@"EntryMode")]
            public string EntryMode { get; set; }

            [LoadColumn(5)]
            [ColumnName(@"Country")]
            public string Country { get; set; }

            [LoadColumn(6)]
            [ColumnName(@"IsInternational")]
            public float IsInternational { get; set; }

            [LoadColumn(7)]
            [ColumnName(@"CardPresent")]
            public float CardPresent { get; set; }

            [LoadColumn(8)]
            [ColumnName(@"DaysSinceLastTransaction")]
            public float DaysSinceLastTransaction { get; set; }

            [LoadColumn(9)]
            [ColumnName(@"TransactionCount24h")]
            public float TransactionCount24h { get; set; }

            [LoadColumn(10)]
            [ColumnName(@"AvgAmount7d")]
            public float AvgAmount7d { get; set; }

            [LoadColumn(11)]
            [ColumnName(@"Fraud")]
            public float Fraud { get; set; }
    }

    // Output of the approval (binary classification) model
    public class FraudPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsLikelyFraud { get; set; }

        public float Probability { get; set; }
        public float Score { get; set; }
    }
