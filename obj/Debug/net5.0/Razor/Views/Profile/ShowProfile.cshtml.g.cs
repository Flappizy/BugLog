#pragma checksum "C:\Users\Hp\source\repos\Buglog\Views\Profile\ShowProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb0c84b1707183dd284679806e1053fe6dd9599b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_ShowProfile), @"mvc.1.0.view", @"/Views/Profile/ShowProfile.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\Hp\source\repos\Buglog\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Hp\source\repos\Buglog\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Hp\source\repos\Buglog\Views\_ViewImports.cshtml"
using Buglog.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Hp\source\repos\Buglog\Views\_ViewImports.cshtml"
using Buglog.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Hp\source\repos\Buglog\Views\_ViewImports.cshtml"
using Buglog.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Hp\source\repos\Buglog\Views\_ViewImports.cshtml"
using Buglog.Dto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Hp\source\repos\Buglog\Views\_ViewImports.cshtml"
using Buglog.Model.Pagination;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Hp\source\repos\Buglog\Views\_ViewImports.cshtml"
using Buglog.Model.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Hp\source\repos\Buglog\Views\_ViewImports.cshtml"
using Buglog.Model.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb0c84b1707183dd284679806e1053fe6dd9599b", @"/Views/Profile/ShowProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99c43dd9fb9b0d6dcd93462caa3dfc6a71f5bac1", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_ShowProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProfileModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div>\r\n    <table class=\"table table-sm table-bordered\">\r\n        <tbody>\r\n            <tr><th>Name</th><td>");
#nullable restore
#line 7 "C:\Users\Hp\source\repos\Buglog\Views\Profile\ShowProfile.cshtml"
                            Write(Model.AppUser.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td></tr>\r\n            <tr><th>Email</th><td>");
#nullable restore
#line 8 "C:\Users\Hp\source\repos\Buglog\Views\Profile\ShowProfile.cshtml"
                             Write(Model.AppUser.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td></tr>\r\n");
#nullable restore
#line 9 "C:\Users\Hp\source\repos\Buglog\Views\Profile\ShowProfile.cshtml"
             if (Model.Roles.Count() != 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr><th>Role</th><td>");
#nullable restore
#line 11 "C:\Users\Hp\source\repos\Buglog\Views\Profile\ShowProfile.cshtml"
                                Write(Model.Roles.First());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td></tr>\r\n");
#nullable restore
#line 12 "C:\Users\Hp\source\repos\Buglog\Views\Profile\ShowProfile.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProfileModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
