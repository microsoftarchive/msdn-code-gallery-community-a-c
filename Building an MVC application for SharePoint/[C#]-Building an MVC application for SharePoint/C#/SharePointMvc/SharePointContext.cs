using Microsoft.SharePoint.Client;
using SharePointMvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointMvc
{
    public class SharePointContext : IDisposable
    {
        public IEnumerable<Category> Categories => LoadCategories();

        public IEnumerable<Discussion> DiscussionList => LoadDiscussionList();

        private IEnumerable<Category> LoadCategories()
        {
            Web web = _context.Web;
            _context.Load(web.Lists);
            _context.ExecuteQuery();

            List categoryList = web.Lists.GetByTitle("Categories");
            if (categoryList == null)
            {
                yield break;
            }

            CamlQuery query = CamlQuery.CreateAllItemsQuery();
            ListItemCollection categories = categoryList.GetItems(query);

            _context.Load(categories);
            _context.ExecuteQuery();

            foreach (var category in categories)
            {
                yield return new Category
                {
                    Id = category.Id,
                    Name = category["Title"].ToString(),
                    Description = category["CategoryDescription"].ToString()
                };
            }
        }

        private IEnumerable<Discussion> LoadDiscussionList()
        {
            Web web = _context.Web;
            _context.Load(web.Lists);
            _context.ExecuteQuery();

            List discussionList = web.Lists.GetByTitle("Discussions List");
            if (discussionList == null)
            {
                yield break;
            }

            CamlQuery query = CamlQuery.CreateAllItemsQuery();
            ListItemCollection discussions = discussionList.GetItems(query);

            _context.Load(discussions);
            _context.ExecuteQuery();

            foreach (var discussion in discussions)
            {
                var category = discussion["CategoriesLookup"] as FieldLookupValue;

                yield return new Discussion
                {
                    Subject = discussion["Title"].ToString(),
                    Body = discussion["Body"].ToString(),
                    IsQuestion = (bool)discussion["IsQuestion"],
                    Category = new Category { Id = category.LookupId, Name = category.LookupValue }
                };
            }
        }

        private ClientContext _context = new ClientContext(__sharepointUrl);

        private static string __sharepointUrl => ConfigurationManager.AppSettings["SharePointUrl"];

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
