#pragma checksum "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "293e88af4ed163f796464d9ada2d1ff3353ffe17"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_ShowProjectDetails), @"mvc.1.0.view", @"/Views/Project/ShowProjectDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"293e88af4ed163f796464d9ada2d1ff3353ffe17", @"/Views/Project/ShowProjectDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99c43dd9fb9b0d6dcd93462caa3dfc6a71f5bac1", @"/Views/_ViewImports.cshtml")]
    public class Views_Project_ShowProjectDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProjectDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Issue", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2 class=\"shadow text-capitalize text-center m-4\">Project Details</h2>\r\n<h3 class=\"bg-light m-4\" >Project Name : ");
#nullable restore
#line 4 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                                    Write(Model.ProjectName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n");
#nullable restore
#line 6 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
 if (Model.ProjectIssues.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <h4 class=""text-center"">List of project issues</h4>
    <div class=""table-responsive"">
        <table class=""table table-sm table-bordered table-striped"">
            <tr>
                <th>Issue Title</th>
                <th>Status</th>
                <th>Priority</th>
                <th>Assignee</th>
                <th>Date Created</th>
                <th>Date Closed</th>
            </tr>
            <tbody>
");
#nullable restore
#line 20 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                 foreach (Issue issue in Model.ProjectIssues)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 23 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                       Write(issue.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 24 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                       Write(issue.StatusName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 25 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                       Write(issue.PriorityName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 26 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                         if (issue.MemberId != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>");
#nullable restore
#line 28 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                           Write(issue.MemberName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 29 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>No one is assigned to this issue yet</td>\r\n");
#nullable restore
#line 33 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 34 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                       Write(issue.DateCreated.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 35 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                         if (issue.DateClosed != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>");
#nullable restore
#line 37 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                           Write(issue.DateClosed.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 38 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>Issue not yet resolved</td>\r\n");
#nullable restore
#line 42 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tr>\r\n");
#nullable restore
#line 44 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
#nullable restore
#line 48 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>No Issue within Project</h4>\r\n");
#nullable restore
#line 52 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<h5>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "293e88af4ed163f796464d9ada2d1ff3353ffe1710556", async() => {
                WriteLiteral("Add Issue");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "C:\Users\Hp\source\repos\Buglog\Views\Project\ShowProjectDetails.cshtml"
                                                                                     WriteLiteral(Model.ProjectId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h5>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProjectDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
