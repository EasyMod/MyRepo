using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kursovaya_ASP_NET.Models.Repository;
using System.Web.Routing;

namespace Kursovaya_ASP_NET.Controllers
{
    public partial class CategoryList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected IEnumerable<string> GetCategories()
        {
            return new Repository().Games
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(x => x);
        }

        protected string CreateHomeLinkHtml()
        {
            string path = RouteTable.Routes.GetVirtualPath(null, null).VirtualPath;
            return string.Format("<a href='{0}'>Главная</a>", path);
        }

        protected string CreateLinkHtml(string category)
        {
            string selectedCategory = (string)Page.RouteData.Values["category"] ?? Request.QueryString["category"];
            string path = RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary() { { "category", category }, { "page", "1" } }).VirtualPath;
            return string.Format("<a href='{0}' {2}>{1}</a>", path, category, category == selectedCategory ? "class='selected'" : "");
        }
    }
}