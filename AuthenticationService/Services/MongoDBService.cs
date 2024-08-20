using AuthenticationService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;


namespace AuthenticationService.Services;

public class MongoDBService
{
    private readonly IMongoCollection<User> _userCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _userCollection = database.GetCollection<User>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<User>> GetAsync() {
        return await _userCollection.Find(user => true).ToListAsync();
    }

    public async Task<User> GetByUserAsync(string email, string password)
    {
        var filter = Builders<User>.Filter.And(
                     Builders<User>.Filter.Eq(user => user.Email, email),
                     Builders<User>.Filter.Eq(user => user.Password, password)
                     );
        return await _userCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(User User) { }
    public async Task AddToUserAsync(string id, string movieId) { }
    public async Task DeleteAsync(string id) { }

}