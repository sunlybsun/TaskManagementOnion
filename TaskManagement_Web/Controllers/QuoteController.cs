using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagement;
using TaskManagement_Repo;
using TaskManagement_Service;

namespace TaskManagement_Web.Controllers
{


    [Authorize]
    public class QuoteController : ApiController
    {
        QuoteService Service = new QuoteService();

        public QuoteController(){}

        // public QuoteController(QuoteService service)
        //{
        //    this.Service = service;
        //}

        [Route("Quote")]
        public IEnumerable<Quote> Get()
        {

            return this.Service.GetQuotesAll();


        }



        [Route("Quote/{id}")]
        public IHttpActionResult Get(int id)
        {

            var result = this.Service.GetQuoteByID(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
                
            
        }



        // POST <controller>
        [Route("Quote")]
        public IHttpActionResult Post([FromBody] Quote quote)
        {
            try
            {

                this.Service.AddNewQuote(quote);
                    return Ok();
                
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid data.");
            }
        }



        // PUT <controller>/5
        [Route("Quote/{id}")]
        public IHttpActionResult Put(int id, [FromBody] Quote quote)
        {
            try
            {

                var entity = Service.GetQuoteByID(id);
                    entity.QuoteID = quote.QuoteID;
                    entity.QuoteType = quote.QuoteType;
                    entity.Contact = quote.Contact;
                    entity.Task = quote.Task;
                    entity.DueDate = quote.DueDate;
                    entity.TaskType = quote.TaskType;

                this.Service.UpdateQuote(entity);
                    return Ok();
                
            }
            catch (Exception ex)
            {
                return BadRequest("Not a valid model");
            }
        }




        // DELETE <controller>/5
        [Route("Quote/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {

                this.Service.DeleteQuote(id);
                    return Ok();
                
            }
            catch (Exception ex)
            {
                return BadRequest("Not a valid Quote id");
            }
        }
    }
}