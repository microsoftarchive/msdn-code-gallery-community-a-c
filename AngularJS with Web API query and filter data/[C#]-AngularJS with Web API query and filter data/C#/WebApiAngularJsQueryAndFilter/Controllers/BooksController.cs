using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiAngularJsQueryAndFilter.Models;
using System.Data.Entity;
using WebApiAngularJsQueryAndFilter.ViewModels;
using System.Linq.Expressions;
using System.Dynamic;

namespace WebApiAngularJsQueryAndFilter.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private SampleContext context = new SampleContext("bookConn");

        public BooksController()
        {

        }

        [HttpPost]
        [Route("QueryOptions")]
        public async Task<IHttpActionResult> QueryOptions(OptionsBindingModel options)
        {
            
            dynamic filters = new ExpandoObject();

            if (options != null && options.Filters != null)
            {
                //the filter values should be unique 'display' strings 
                if (options.Filters.Contains(FilterOptions.authors))
                {
                    filters.Authors = await context.Authors
                                                    .Select(a => new AuthorViewModel() { 
                                                        Id = a.Id,
                                                        Name = a.Name
                                                    })
                                                    .ToListAsync();
                }
                
                if (options.Filters.Contains(FilterOptions.classifications))
                {
                    filters.Classifications = await context.Classifications
                                                    .Select(c => new ClassificationViewModel() { 
                                                        Id = c.Id,
                                                        Name = c.Name
                                                    })
                                                    .ToListAsync();
                }
                
                if (options.Filters.Contains(FilterOptions.publishers))
                {
                    filters.Publishers = await context.Publishers
                                                    .Select(p => new PublisherViewModel() { 
                                                        Id = p.Id,
                                                        Name = p.Name
                                                    })
                                                    .ToListAsync();
                }
            }
                        
            var orderByOptions = Enum.GetNames(typeof(OrderByOptions));

            return Ok(
                new {
                    options = new
                    {
                        selectableFilters = filters,
                        allFilterTypes = Enum.GetNames(typeof(FilterOptions)),
                        orderByOptions = orderByOptions,
                    },
                    query = new
                    {
                        orderBy= "",
                        searchText= "",
                        authors = new List<string>(),
                        publishers = new List<string>(),
                        classifications = new List<string>()
                    }
                });
        }

        [HttpPost] 
        public async Task<IHttpActionResult> Search(QueryBindingModel queryOptions)
        {
            if (queryOptions == null)
            {
                return BadRequest("no query options provided");
            }

            //create the initial query...
            var query = context.Books
                                .Include(b => b.Author)
                                .Include(b => b.Publisher)
                                .Include(b => b.Classification);

            //for each query option if it has values add it to the query
            if (!string.IsNullOrEmpty(queryOptions.SearchText))
            {
                query = query.Where(b => b.Title.Contains(queryOptions.SearchText) || b.Author.Name.Contains(queryOptions.SearchText));
            }
                        
            if (queryOptions.Classifications != null && queryOptions.Classifications.Count() > 0)
            {
                query = query.Where(b => queryOptions.Classifications.Contains(b.Classification.Id));
            }

            if (queryOptions.Publishers != null && queryOptions.Publishers.Count() > 0)
            {
                query = query.Where(b => queryOptions.Publishers.Contains(b.Publisher.Id));
            }

            if (queryOptions.Authors != null && queryOptions.Authors.Count() > 0)
            {
                query = query.Where(b => queryOptions.Authors.Contains(b.Author.Id));
            }

            query = CreateOrderByExpression(query, queryOptions.OrderBy);

            var results = await query.ToListAsync();
      
            return Ok(new { 
                Books = results
            });
        }

        private IQueryable<Book> CreateOrderByExpression(IQueryable<Book> query, OrderByOptions orderByoption)
        {            
            switch (orderByoption)
            {
                case OrderByOptions.author:
                    query = query.OrderBy(b => b.Author.Name);
                    break;
                case OrderByOptions.publisher:
                    query = query.OrderBy(b => b.Publisher.Name);
                    break;
                default:
                    query = query.OrderBy(b => b.Title);
                    break;
            }

            return query;
        }
    
    }
}
