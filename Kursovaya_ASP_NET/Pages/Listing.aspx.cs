using Kursovaya_ASP_NET.Models;
using Kursovaya_ASP_NET.Models.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kursovaya_ASP_NET.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repository = new Repository();
        private int pageSize = 4;
        protected int CurrentPage
        {
            get
            {
                int page;
                page = GetPageFromReques();
                return page > MaxPage ? MaxPage : page;
            }
        }
        protected int MaxPage
        {
            get
            {
                int prodCount = FilterGames().Count();
                return (int)Math.Ceiling((decimal)prodCount / pageSize);
            }

        }

        private int GetPageFromReques()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ?? Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;

        }


        public IEnumerable<Game> GetGames()
        {
            return FilterGames()
                .OrderBy(g => g.GameId)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }

        private IEnumerable<Game> FilterGames()
        {
            IEnumerable<Game> games = repository.Games;
            string currentCategory = (string)RouteData.Values["category"] ?? Request.QueryString["category"];
            return currentCategory == null ? games : games.Where(p => p.Category == currentCategory);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Culture = "uk-UA";
            UICulture = "uk-UA";
        }

    }
}