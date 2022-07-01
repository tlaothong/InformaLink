﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InformaLink.WebApi.Models.Dbs
{
    public class PrimeRecord
    {
        [BsonId]
        public ObjectId _Id { get; set; }
        public string? Name { get; set; }
        public string? IPADress { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
        public int Port { get; set; }
        public string? Channel { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string? Direction { get; set; }
        public string? Company { get; set; }
        public string? Owner { get; set; }
        public string? Station { get; set; }
        public string? Note { get; set; }
    }
}
