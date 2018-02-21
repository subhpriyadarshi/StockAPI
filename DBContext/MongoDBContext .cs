using System;
using MongoDB.Driver;
using TodoApi.Models;

public class MongoDBContext 
    { 
        public static string ConnectionString { get; set; } 
        public static string DatabaseName { get; set; } 
        public static bool IsSSL { get; set; } 
 
        private IMongoDatabase _database { get; } 
 
        public MongoDBContext() 
        { 
            try 
            { 
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017")); 
                if (IsSSL) 
                { 
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 }; 
                } 
                var mongoClient = new MongoClient(settings); 
                _database = mongoClient.GetDatabase("bullbazaar"); 
            } 
            catch (Exception ex) 
            { 
                throw new Exception("Can not access to db server.", ex); 
            } 
        } 
 
        public IMongoCollection<TodoItem> TodoItems 
        { 
            get 
            { 
                return _database.GetCollection<TodoItem>("TodoItem"); 
            } 
        } 

        public IMongoCollection<PortfolioStockDetail> MyPortfolio 
        { 
            get 
            { 
                return _database.GetCollection<PortfolioStockDetail>("MyPortfolio"); 
            } 
        } 

        public IMongoCollection<ListedStocks> ListedStocks 
        { 
            get 
            { 
                return _database.GetCollection<ListedStocks>("ListedStocks"); 
            } 
        }
    } 