#pragma checksum "D:\Task\Task\Task.Web\Views\Users\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d198ac5b4716f38cfbdbe1ea49c28c53c3c9cf8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Edit), @"mvc.1.0.view", @"/Views/Users/Edit.cshtml")]
namespace AspNetCore
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
#line 1 "D:\Task\Task\Task.Web\Views\Users\Edit.cshtml"
using Task.Services.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d198ac5b4716f38cfbdbe1ea49c28c53c3c9cf8", @"/Views/Users/Edit.cshtml")]
    public class Views_Users_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/form.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Users/Edit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/edit.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5d198ac5b4716f38cfbdbe1ea49c28c53c3c9cf84432", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d198ac5b4716f38cfbdbe1ea49c28c53c3c9cf85551", async() => {
                WriteLiteral("\r\n    <div class=\"column\">\r\n        ");
#nullable restore
#line 8 "D:\Task\Task\Task.Web\Views\Users\Edit.cshtml"
   Write(Html.Hidden("UserId",Model.UserId,new {id = Model.UserId, Name= Model.UserId}));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <div>\r\n        <div class=\"form-element form-lable\">");
#nullable restore
#line 10 "D:\Task\Task\Task.Web\Views\Users\Edit.cshtml"
                                        Write(Html.LabelFor(m=>m.Firstname));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n        <div class=\"form-element form-input\">");
#nullable restore
#line 11 "D:\Task\Task\Task.Web\Views\Users\Edit.cshtml"
                                        Write(Html.TextBoxFor(m=>m.Firstname));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n    </div>\r\n    <div>\r\n        <div class=\"form-element form-lable\">");
#nullable restore
#line 14 "D:\Task\Task\Task.Web\Views\Users\Edit.cshtml"
                                        Write(Html.LabelFor(m=>m.Lastname));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n        <div class=\"form-element form-input\">");
#nullable restore
#line 15 "D:\Task\Task\Task.Web\Views\Users\Edit.cshtml"
                                        Write(Html.TextBoxFor(m=>m.Lastname));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n    </div>\r\n    <div >\r\n        <div class=\"form-element form-lable\">");
#nullable restore
#line 18 "D:\Task\Task\Task.Web\Views\Users\Edit.cshtml"
                                        Write(Html.LabelFor(m=>m.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n        <div class=\"form-element form-input\">");
#nullable restore
#line 19 "D:\Task\Task\Task.Web\Views\Users\Edit.cshtml"
                                        Write(Html.TextBoxFor(m=>m.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n        <span asp-validation-for=\"Email\"></span>\r\n    </div>\r\n    <div>\r\n        <div class=\"form-element form-lable\">");
#nullable restore
#line 23 "D:\Task\Task\Task.Web\Views\Users\Edit.cshtml"
                                        Write(Html.LabelFor(m=>m.Phone));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n        <div class=\"form-element form-input\">");
#nullable restore
#line 24 "D:\Task\Task\Task.Web\Views\Users\Edit.cshtml"
                                        Write(Html.TextBoxFor(m=>m.Phone));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n        <span asp-validation-for=\"Phone\"></span>\r\n    </div>\r\n    <div>\r\n        <div class=\"form-element form-lable\">Title</div>\r\n        <div class=\"form-element form-input\">\r\n            <select id=\"TitleId\" name=\"TitleId\"><option");
                BeginWriteAttribute("value", " value=\"", 1275, "\"", 1283, 0);
                EndWriteAttribute();
                WriteLiteral("></option>\r\n            </select>\r\n        </div>\r\n    <div >\r\n    </div>\r\n        <div class=\"form-element form-lable\">Country</div>\r\n        <div class=\"form-element form-input\">\r\n            <select id=\"Countries\" ><option");
                BeginWriteAttribute("value", " value=\"", 1509, "\"", 1517, 0);
                EndWriteAttribute();
                WriteLiteral("></option>\r\n            </select>\r\n        </div>\r\n    </div>\r\n    <div >\r\n        <div class=\"form-element form-lable\">City</div>\r\n        <div class=\"form-element form-input\">\r\n            <select id=\"CityId\" name=\"CityId\"><option");
                BeginWriteAttribute("value", " value=\"", 1750, "\"", 1758, 0);
                EndWriteAttribute();
                WriteLiteral("></option>\r\n            </select>\r\n        </div>\r\n    </div>\r\n    <div>\r\n        <div class=\"form-element form-lable\">");
#nullable restore
#line 49 "D:\Task\Task\Task.Web\Views\Users\Edit.cshtml"
                                        Write(Html.LabelFor(m=>m.Comments));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n        <div class=\"form-element form-input\">");
#nullable restore
#line 50 "D:\Task\Task\Task.Web\Views\Users\Edit.cshtml"
                                        Write(Html.TextAreaFor(m=>m.Comments));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n    </div>\r\n    <div><button type=\"submit\">Save</button></div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js\"></script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d198ac5b4716f38cfbdbe1ea49c28c53c3c9cf811604", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script>\r\nlet model = ");
#nullable restore
#line 59 "D:\Task\Task\Task.Web\Views\Users\Edit.cshtml"
       Write(Html.Raw(Json.Serialize(Model)));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
