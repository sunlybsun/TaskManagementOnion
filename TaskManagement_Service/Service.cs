using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagement_Repo;
using TaskManagement;

namespace TaskManagement_Service
{
    public class QuoteService
    {

        //private IRepository<Quote> QuoteRepository;
        IRepository<Quote> QuoteRepository = new Repository<Quote>();

        public QuoteService()
        {

        }

        //public QuoteService(Repository<Quote> QuoteRepository)
        //{
        //    this.QuoteRepository = QuoteRepository;
            
       //}


        public IEnumerable<Quote> GetQuotesAll()
        {
            return QuoteRepository.GetAll();
        }

        public Quote GetQuoteByID(int id)
        {
            return QuoteRepository.GetByID(id);
        }

        public void AddNewQuote(Quote quote)
        {
             QuoteRepository.Add(quote);
        }

        public void UpdateQuote(Quote quote)
        {
            QuoteRepository.Update(quote);
        }

        public void DeleteQuote(int id)
        {

            Quote quote = QuoteRepository.GetByID(id);
            QuoteRepository.Delete(quote);
        }





    }
}