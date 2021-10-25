using System;
using System.Xml;
using System.Net.Http;
using CodeHollow.FeedReader;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RW.Data;
using RW.Domain.Models;

using static System.Console;

namespace RW.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private const string LogFilePath = @"logs/log.txt";

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public override async Task StartAsync(CancellationToken cToken) {
            LogToFile("WorkerService Started");
            LogToConsole("WorkerService Started");
            await base.StartAsync(cToken);
        }

        public override async Task StopAsync(CancellationToken cToken) {
            LogToFile("WorkerService Stopped");
            LogToConsole("WorkerService Stopped");
            await base.StopAsync(cToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // MAYBE DEPENDENCY INJECT AS SERVICE???
                //ReadFeedTest();
                //AddToDbTest();
                //PrintDbItems();
                LogToFile("ExecuteAsync");
                LogToConsole("ExecuteAsync");
                await Task.Delay(10000, stoppingToken);
            }
        }

        private async void ReadFeedTest() {
            List<Uri> rssFeeds = new List<Uri> {
                new Uri(@"https://www.techvisor.nl/Rss/RssArtikelen"),
            };

            var client = new HttpClient();

            foreach (var rssFeed in rssFeeds) {
                var result = await client.GetStreamAsync(rssFeed); 

                using (var xmlReader = XmlReader.Create(result)) {
                    var feed = await FeedReader.ReadAsync(rssFeed.ToString());

                    WriteLine($"{feed.Title}");

                    foreach (var feedItem in feed.Items) {
                        PrintItem(feedItem);
                    }
                }
            }
        }

        private void PrintItem(FeedItem fi) {
            WriteLine($"{fi.PublishingDateString} - {fi.Title}\n{fi.Link}\n{fi.Description}\n---\n");
        }

        private void AddToDbTest() {
            using var scope = _serviceScopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<RWDbContext>();

            article tmp = new();
            tmp.title = "testing";
            tmp.link = "linktest";
            tmp.publication = "pubtest";

            dbContext.Add(tmp);
            dbContext.SaveChanges();
        }

        private void PrintDbItems() {
            using var scope = _serviceScopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<RWDbContext>();

            foreach (var article in dbContext.articles) {
                WriteLine($"{article.title}\n{article.link}\n{article.publication}");
            }
        }

        private void LogToFile(string message) {
            File.AppendAllText(LogFilePath, $"{DateTime.Now}: {message}.\n");
        }

        private void LogToConsole(string message) {
            _logger.LogInformation($"{DateTimeOffset.Now}: {message}.");
        }

    }
}
