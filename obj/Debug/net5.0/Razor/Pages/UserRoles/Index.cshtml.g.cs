#pragma checksum "C:\Users\tata-\SeniorLibrary\Pages\UserRoles\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f2a23699a9392bd7f5fdec9004076068ac8247f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SeniorLibrary.Pages.UserRoles.Pages_UserRoles_Index), @"mvc.1.0.razor-page", @"/Pages/UserRoles/Index.cshtml")]
namespace SeniorLibrary.Pages.UserRoles
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\tata-\SeniorLibrary\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tata-\SeniorLibrary\Pages\_ViewImports.cshtml"
using SeniorLibrary;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\tata-\SeniorLibrary\Pages\_ViewImports.cshtml"
using SeniorLibrary.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f2a23699a9392bd7f5fdec9004076068ac8247f", @"/Pages/UserRoles/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c5abc707b49aba59f70921a1f61ed10b45479bb", @"/Pages/_ViewImports.cshtml")]
    public class Pages_UserRoles_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\tata-\SeniorLibrary\Pages\UserRoles\Index.cshtml"
  
    ViewData["Title"] = "UserRoles";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>User Roles</h1>\r\n<table class=\"table table-striped\">\r\n    <thead>\r\n        <tr>\r\n            <th>UserId</th>\r\n            <th>Email</th>\r\n            <th>Roles</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 16 "C:\Users\tata-\SeniorLibrary\Pages\UserRoles\Index.cshtml"
         foreach (var user in Model.userRolesViewModel)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 19 "C:\Users\tata-\SeniorLibrary\Pages\UserRoles\Index.cshtml"
           Write(user.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 20 "C:\Users\tata-\SeniorLibrary\Pages\UserRoles\Index.cshtml"
           Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 21 "C:\Users\tata-\SeniorLibrary\Pages\UserRoles\Index.cshtml"
           Write(string.Join(" , ", user.Roles.ToList()));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 23 "C:\Users\tata-\SeniorLibrary\Pages\UserRoles\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SeniorLibrary.Pages.UserRoles.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SeniorLibrary.Pages.UserRoles.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SeniorLibrary.Pages.UserRoles.IndexModel>)PageContext?.ViewData;
        public SeniorLibrary.Pages.UserRoles.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591