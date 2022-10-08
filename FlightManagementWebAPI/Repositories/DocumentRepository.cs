using DomainModel.Models;
using FlightManagementWebAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace FlightManagementWebAPI.Repositories
{
    public class DocumentRepository
    {
        private readonly AirportSystemContext _airportSystemContext;
        public DocumentRepository(AirportSystemContext airportSystemContext)
        {
            _airportSystemContext = airportSystemContext;
        }

        public List<Document> GetDocuments()
        {
            return _airportSystemContext.Documents.ToList();
        }
        public void InsertDocument(Document document)
        {
            _airportSystemContext.Documents.Add(document);
            _airportSystemContext.SaveChanges();
        }

        public Document GetDocument(int documentId)
        {
            return _airportSystemContext.Documents.
                FirstOrDefault(document => document.Id.Equals(documentId));
        }

        public void UpdateDocument(Document document)
        {
            var documentForUpdate = GetDocument(document.Id);
            if (documentForUpdate != null)
            {
                documentForUpdate.FirstName = document.FirstName;
                documentForUpdate.LastName = document.LastName;
                documentForUpdate.Type = document.Type;
                documentForUpdate.Number = document.Number;
                documentForUpdate.ExpirationDate = document.ExpirationDate;
                _airportSystemContext.SaveChanges();
            }
        }

        public void DeleteDocument(int documentId)
        {
            var document = GetDocument(documentId);
            if (document != null)
            {
                _airportSystemContext.Documents.Remove(document);
                _airportSystemContext.SaveChanges();
            }
        }
    }
}
