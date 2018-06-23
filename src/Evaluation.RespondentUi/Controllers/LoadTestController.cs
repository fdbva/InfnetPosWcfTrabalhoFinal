using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RespondentUiWcfService;

namespace Evaluation.RespondentUi.Controllers
{
    public class LoadTestController : Controller
    {
        public async Task<string> LoadTestAdd()
        {
            try
            {
                const int loadTestSize = 100;
                var questionsViewModel = new List<QuestionViewModel>();
                for (var i = 0; i < loadTestSize; i++)
                {
                    questionsViewModel.Add(new QuestionViewModel { Id = Guid.NewGuid(), Text = $"Question {i}" });
                }
                var stopwatch = Stopwatch.StartNew();
                var respondentUiServiceClient = new RespondentUiServiceClient();
                await respondentUiServiceClient.OpenAsync();

                //await respondentUiServiceClient.AddAsync(questionsViewModel.Take(1).First());

                var tasks = questionsViewModel.Select(x => respondentUiServiceClient.AddAsync(x));
                var results = await Task.WhenAll(tasks);

                await respondentUiServiceClient.CloseAsync();

                var resultString = string.Join(Environment.NewLine, results.ToList().Select(x => x.Text));
                return $"Finished LoadTestAdd in {stopwatch.ElapsedMilliseconds}ms, {Environment.NewLine} {resultString}";

                //return $"Finished LoadTestAdd in {stopwatch.ElapsedMilliseconds}ms";
            }
            catch (FaultException e)
            {
                Console.WriteLine(e);
                return e.Message;
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
                throw;
            }
        }
        public async Task<string> LoadTesAddSingleTransactionAsync()
        {
            try
            {
                const int loadTestSize = 100;
                var questionsViewModel = new List<QuestionViewModel>();
                for (var i = 0; i < loadTestSize; i++)
                {
                    questionsViewModel.Add(new QuestionViewModel { Id = Guid.NewGuid(), Text = $"Question {i}" });
                }
                var stopwatch = Stopwatch.StartNew();
                var respondentUiServiceClient = new RespondentUiServiceClient();
                //await respondentUiServiceClient.OpenAsync();

                //await respondentUiServiceClient.AddAsync(questionsViewModel.Take(1).First());

                var tasks = questionsViewModel.Select(x => respondentUiServiceClient.AddWithoutCommitAsync(x));
                var results = await Task.WhenAll(tasks);
                await respondentUiServiceClient.CommitAsync();

                await respondentUiServiceClient.CloseAsync();

                var resultString = string.Join(Environment.NewLine, results.ToList().Select(x => x.Text));
                return $"Finished LoadTestAdd in {stopwatch.ElapsedMilliseconds}ms, {Environment.NewLine} {resultString}";

                //return $"Finished LoadTestAdd in {stopwatch.ElapsedMilliseconds}ms";
            }
            catch (FaultException e)
            {
                Console.WriteLine(e);
                return e.Message;
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
                throw;
            }
        }
    }
}
