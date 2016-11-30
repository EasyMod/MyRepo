<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="Kursovaya_ASP_NET.Controllers.CategoryList" %>
<%= CreateHomeLinkHtml() %>
<% foreach (string category in GetCategories())
    {
        Response.Write(CreateLinkHtml(category));
    }
         %>