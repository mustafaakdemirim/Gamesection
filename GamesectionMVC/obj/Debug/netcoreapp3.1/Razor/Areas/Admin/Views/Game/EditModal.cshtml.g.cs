#pragma checksum "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/Game/EditModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59f296d54c41f085c098e3d65de6f07bf4446374"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GamesectionMVC.Areas.Admin.Views.Game.Areas_Admin_Views_Game_EditModal), @"mvc.1.0.view", @"/Areas/Admin/Views/Game/EditModal.cshtml")]
namespace GamesectionMVC.Areas.Admin.Views.Game
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
#line 2 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/_ViewImports.cshtml"
using GamesectionMVC.Areas.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/_ViewImports.cshtml"
using GamesectionMVC.Areas.Admin.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/_ViewImports.cshtml"
using Entity.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/_ViewImports.cshtml"
using Entity.POCO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/_ViewImports.cshtml"
using GamesectionMVC.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/_ViewImports.cshtml"
using Gamesection.Views.Shared;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59f296d54c41f085c098e3d65de6f07bf4446374", @"/Areas/Admin/Views/Game/EditModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2eac23ecc8511956ad02e91c8d16713f7e696ad8", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Game_EditModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GameDTO>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    <div class=""modal-dialog modal-dialog-centered"" role=""document"">
        <div class=""modal-content modal-content-demo"">
            <div class=""modal-header"">
                <h6 class=""modal-title""></h6><button aria-label=""Close"" class=""close"" data-dismiss=""modal"" type=""button""><span aria-hidden=""true"">&times;</span></button>
            </div>
            <div class=""modal-body"">
                <h6>Güncelle</h6>
                <!--<form action""#"" id=""form"" enctype=""multipart/form-data"" class=""form-horizontal"" onsubmit=""return window.alert(""geldi"");"">-->
                <div class=""form-group"">
                    <label>Oyun Adı</label>
                    <input type=""text"" class=""form-control"" id=""game-name"" name=""game_name""");
            BeginWriteAttribute("value", " value=\"", 759, "\"", 782, 1);
#nullable restore
#line 12 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/Game/EditModal.cshtml"
WriteAttributeValue("", 767, Model.GameName, 767, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                    <input type=\"text\" style=\"display : none;\" class=\"form-control\" id=\"game-ıd\" name=\"game_ıd\"");
            BeginWriteAttribute("value", " value=\"", 896, "\"", 913, 1);
#nullable restore
#line 13 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/Game/EditModal.cshtml"
WriteAttributeValue("", 904, Model.ID, 904, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                </div>\n                <div class=\"form-group\">\n                    <label>Açıklama</label>\n                    <textarea style=\"height:250px;\" type=\"text\" class=\"form-control\" id=\"game-description\" name=\"game_description\">");
#nullable restore
#line 17 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/Game/EditModal.cshtml"
                                                                                                                              Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea>\n                </div>\n                <div class=\"form-group\">\n                    <label>Fiyat</label>\n                    <input type=\"text\" class=\"form-control\" id=\"game-price\" name=\"game_price\"");
            BeginWriteAttribute("value", " value=\"", 1383, "\"", 1403, 1);
#nullable restore
#line 21 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/Game/EditModal.cshtml"
WriteAttributeValue("", 1391, Model.Price, 1391, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
                <!--<div class=""form-group"">-->
                    <label>Kategori</label>
                    <select id=""categorySelect"" class=""form-control select2-no-search select2-hidden-accessible"" >
                        <!--<option label=""Bir Tane Seçin"" data-select2-id=""15""></option>-->
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59f296d54c41f085c098e3d65de6f07bf44463747217", async() => {
                WriteLiteral("\n                            ");
#nullable restore
#line 28 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/Game/EditModal.cshtml"
                       Write(Model.GameCategoryName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/Game/EditModal.cshtml"
                                     Write(Model.CategoryID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-adr", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/Game/EditModal.cshtml"
                                                        WriteLiteral(Model.GameCategoryName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 30 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/Game/EditModal.cshtml"
                         foreach (var item in Model.Categories)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59f296d54c41f085c098e3d65de6f07bf444637410038", async() => {
#nullable restore
#line 32 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/Game/EditModal.cshtml"
                                                                               Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/Game/EditModal.cshtml"
                                         Write(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-adr", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/Game/EditModal.cshtml"
                                                   WriteLiteral(item.CategoryName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 33 "/Users/mustafaakdemir/Desktop/Gamesection/GamesectionMVC/Areas/Admin/Views/Game/EditModal.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </select>
                <!---</div>-->
                <label>Oyun Görseli</label>
                <div class=""input-group file-browser"">
                    <input type=""text"" class=""form-control browse-file"" placeholder=""choose"" readonly>
                    <label class=""input-group-btn"">
                        <span class=""btn btn-default"">
                            Browse <input type=""file"" name=""resim"" id=""dosya"" style=""display: none;"" multiple>
                        </span>
                    </label>
                </div>
                <!--</form>-->
            </div>
            <div class=""modal-footer"">
                <button onclick=""güncelle()"" type=""submit"" data-dismiss=""modal"" class=""btn ripple btn-primary"">Gönder</button>
                <button class=""btn ripple btn-secondary"" data-dismiss=""modal"" type=""button"">Close</button>
            </div>
        </div>
    </div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GameDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
