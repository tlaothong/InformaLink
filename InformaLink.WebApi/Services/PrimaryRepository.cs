using InformaLink.WebApi.Models.Csv;
using InformaLink.WebApi.Models.Dbs;
using MongoDB.Bson;
using MongoDB.Driver;

namespace InformaLink.WebApi.Services
{
    public class PrimaryRepository
    {
        private IMongoCollection<PrimeRecord> _primeRecords;
        public PrimaryRepository(IConfiguration configuration)
        {
            var connectionString = configuration["PrimaryConnectionString"]
                ?? throw new ArgumentNullException(nameof(configuration));

            var conn = new MongoClient(connectionString);
            var db = conn.GetDatabase("migration");
            _primeRecords = db.GetCollection<PrimeRecord>("prima");
        }

        public async Task SaveRecords(IEnumerable<PrimaryRecord> records)
        {
            var writeModels = records.Select(record =>
                new InsertOneModel<PrimeRecord>(new PrimeRecord
                {
                    _Id = ObjectId.GenerateNewId(),
                    Name = record.Name,
                    IPADress = record.IPADress,
                    User = record.User,
                    Password = record.Password,
                    Port = record.Port,
                    Channel = record.Channel,
                    Lat = record.Lat,
                    Long = record.Long,
                    Direction = record.Direction,
                    Company = record.Company,
                    Owner = record.Owner,
                    Station = record.Station,
                    Note = record.Note,
                }));

            await _primeRecords.BulkWriteAsync(writeModels);
        }

        public Task<List<PrimeRecord>> GetRecords()
        {
            return _primeRecords.Find(Builders<PrimeRecord>.Filter.Empty).ToListAsync();
        }
    }
}
