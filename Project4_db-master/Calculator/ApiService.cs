using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Calculator.Models;

namespace Calculator
{
    internal class ApiService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        static string apiUrl = "http://3.6.127.17:8080/exam/";
        public ExamQuestionModel examQuestion { get; private set; }

        public ApiService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<ExamQuestionModel> getExamQuestion(int questionNumber)
        {
            examQuestion = new ExamQuestionModel();

            Uri uri = new Uri(string.Format($"{apiUrl}{questionNumber}", string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    examQuestion = JsonSerializer.Deserialize<ExamQuestionModel>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return examQuestion;
        }
    }
}
