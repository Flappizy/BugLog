#pragma checksum "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50b8f29e06581b06d7113c44bd350e97df7ffdf6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Activity_ShowActivities), @"mvc.1.0.view", @"/Views/Activity/ShowActivities.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b8f29e06581b06d7113c44bd350e97df7ffdf6", @"/Views/Activity/ShowActivities.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99c43dd9fb9b0d6dcd93462caa3dfc6a71f5bac1", @"/Views/_ViewImports.cshtml")]
    public class Views_Activity_ShowActivities : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AuditViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-action", "ShowActivities", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("url-path", "pageNumber", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class", "btn", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class-normal", "btn-outline-dark", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class-selected", "btn-primary", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-group pull-right m-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Buglog.Model.Infrastructure.PageLinkTagHelper __Buglog_Model_Infrastructure_PageLinkTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
 if (Model.Audits.Count() == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>There is presently no Activity</h3>\r\n");
#nullable restore
#line 6 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <h2 class=""shadow text-capitalize text-center m-4"">Activities</h2>
    <div class=""table-responsive"">
        <table class=""table table-sm table-bordered table-striped"">
            <thead>
                <tr>
                    <th>User</th>
                    <th>Operation</th>
                    <th>Date of Operation</th>
                    <th>Old Values</th>
                    <th>New Values</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 22 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                 foreach (Audit audit in Model.Audits)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 25 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                       Write(audit.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 26 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                         if (audit.Operation == "Created")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>");
#nullable restore
#line 28 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                           Write(audit.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" has added ");
#nullable restore
#line 28 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                                     Write(audit.EntityTableName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 28 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                                                             Write(audit.EntityName);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</td>\r\n");
#nullable restore
#line 29 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"

                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                         if (audit.Operation == "Updated")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>");
#nullable restore
#line 33 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                           Write(audit.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" has ");
#nullable restore
#line 33 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                               Write(audit.Operation);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 33 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                                                Write(audit.EntityTableName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 33 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                                                                        Write(audit.EntityName);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</td>\r\n");
#nullable restore
#line 34 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"

                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                         if (audit.Operation == "Deleted")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>");
#nullable restore
#line 38 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                           Write(audit.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" has deleted ");
#nullable restore
#line 38 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                                       Write(audit.EntityTableName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 38 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                                                               Write(audit.EntityName);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</td>\r\n");
#nullable restore
#line 39 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 41 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                       Write(audit.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n");
#nullable restore
#line 43 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                             if (audit.Operation != "Deleted")
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                 foreach (KeyValuePair<string, object> item in Model.AuditObject.OldValue)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                     if (item.Key.EndsWith("Id"))
                                    {
                                        continue;
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p>");
#nullable restore
#line 51 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                  Write(item.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral(" = ");
#nullable restore
#line 51 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                              Write(item.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br /></p>\r\n");
#nullable restore
#line 52 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 56 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                             if (audit.Operation != "Deleted")
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                 foreach (KeyValuePair<string, object> item in Model.AuditObject.NewValue)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                     if (item.Key.EndsWith("Id"))
                                    {
                                        continue;
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p>");
#nullable restore
#line 64 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                  Write(item.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral(" = ");
#nullable restore
#line 64 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                              Write(item.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br /></p>\r\n");
#nullable restore
#line 65 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 69 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n        <div class=\"text-center\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "50b8f29e06581b06d7113c44bd350e97df7ffdf616410", async() => {
            }
            );
            __Buglog_Model_Infrastructure_PageLinkTagHelper = CreateTagHelper<global::Buglog.Model.Infrastructure.PageLinkTagHelper>();
            __tagHelperExecutionContext.Add(__Buglog_Model_Infrastructure_PageLinkTagHelper);
#nullable restore
#line 74 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
__Buglog_Model_Infrastructure_PageLinkTagHelper.PageMetadata = Model.PageMetaData;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("page-metadata", __Buglog_Model_Infrastructure_PageLinkTagHelper.PageMetadata, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Buglog_Model_Infrastructure_PageLinkTagHelper.PageAction = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Buglog_Model_Infrastructure_PageLinkTagHelper.UrlPath = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 74 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
__Buglog_Model_Infrastructure_PageLinkTagHelper.PageClassesEnabled = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("page-classes-enabled", __Buglog_Model_Infrastructure_PageLinkTagHelper.PageClassesEnabled, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Buglog_Model_Infrastructure_PageLinkTagHelper.PageClass = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Buglog_Model_Infrastructure_PageLinkTagHelper.PageClassNormal = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Buglog_Model_Infrastructure_PageLinkTagHelper.PageClassSelected = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 79 "C:\Users\Hp\source\repos\Buglog\Views\Activity\ShowActivities.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AuditViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
