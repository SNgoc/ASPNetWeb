#pragma checksum "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\User\Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "946a88bb10b7fdabd19326106f76162f409c07b5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Show), @"mvc.1.0.view", @"/Views/User/Show.cshtml")]
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
#line 1 "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\_ViewImports.cshtml"
using Student_1273498;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\_ViewImports.cshtml"
using Student_1273498.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"946a88bb10b7fdabd19326106f76162f409c07b5", @"/Views/User/Show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"369c5cc0164e6078422e2377f8cdd84dcd2ed533", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Student_1273498.Models.TbUser>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\User\Show.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "946a88bb10b7fdabd19326106f76162f409c07b53491", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Show</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "946a88bb10b7fdabd19326106f76162f409c07b54549", async() => {
                WriteLiteral("\r\n    <h1>User Profile</h1>\r\n    <table>\r\n        <thead>\r\n            <tr>\r\n                <th>");
#nullable restore
#line 18 "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\User\Show.cshtml"
               Write(Html.DisplayNameFor(m => m.Fullname));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 19 "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\User\Show.cshtml"
               Write(Html.DisplayNameFor(m => m.Username));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 20 "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\User\Show.cshtml"
               Write(Html.DisplayNameFor(m => m.Password));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 21 "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\User\Show.cshtml"
               Write(Html.DisplayNameFor(m => m.Address));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 22 "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\User\Show.cshtml"
               Write(Html.DisplayNameFor(m => m.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 26 "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\User\Show.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 29 "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\User\Show.cshtml"
               Write(Html.DisplayFor(mi => item.Fullname));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\User\Show.cshtml"
               Write(Html.DisplayFor(mi => item.Username));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\User\Show.cshtml"
               Write(Html.DisplayFor(mi => item.Password));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 32 "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\User\Show.cshtml"
               Write(Html.DisplayFor(mi => item.Address));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 33 "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\User\Show.cshtml"
               Write(Html.DisplayFor(mi => item.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 35 "N:\Programs\Github\ASPNetWeb\Student_1273498\Student_1273498\Views\User\Show.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Student_1273498.Models.TbUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
