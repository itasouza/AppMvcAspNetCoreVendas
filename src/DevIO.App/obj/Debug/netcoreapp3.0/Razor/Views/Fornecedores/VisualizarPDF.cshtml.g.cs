#pragma checksum "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\VisualizarPDF.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e8f5f7926a770a28cf4e505ec8fa8155d5e6e6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fornecedores_VisualizarPDF), @"mvc.1.0.view", @"/Views/Fornecedores/VisualizarPDF.cshtml")]
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
#line 1 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\_ViewImports.cshtml"
using DevIO.App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\_ViewImports.cshtml"
using DevIO.App.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\VisualizarPDF.cshtml"
using DevIO.App.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e8f5f7926a770a28cf4e505ec8fa8155d5e6e6a", @"/Views/Fornecedores/VisualizarPDF.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f4e717c4124c55203fe493fa8cdf7ca43650315", @"/Views/_ViewImports.cshtml")]
    public class Views_Fornecedores_VisualizarPDF : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DevIO.App.ViewModels.FornecedorViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.7/css/bootstrap.min.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-fallback-href", "~/lib/bootstrap/dist/css/bootstrap.min.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-fallback-test-class", "sr-only", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-fallback-test-property", "position", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-fallback-test-value", "absolute", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/vendor.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/app.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\VisualizarPDF.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"pt-BR\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8e8f5f7926a770a28cf4e505ec8fa8155d5e6e6a6780", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>PDF</title>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8e8f5f7926a770a28cf4e505ec8fa8155d5e6e6a7133", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.FallbackHref = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.FallbackTestClass = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.FallbackTestProperty = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.FallbackTestValue = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8e8f5f7926a770a28cf4e505ec8fa8155d5e6e6a9967", async() => {
                WriteLiteral(@"


    <!-- Start Content-->
    <div class=""container"">

        <br />

        <div class=""row"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-body"">


                        <!-- Invoice Detail-->
                        <div class=""row"">
                            <div class=""col-sm-6"">
                                <div class=""float-left mt-3"">
                                    <p><b>Registros de Fornecedores</b></p>
                                    <p class=""text-muted font-13"">
                                        Lorem Ipsum é simplesmente uma simulação de texto da indústria tipográfica e de impressos, e vem sendo utilizado desde o século XVI, quando um impressor desconhecido pegou uma bandeja
                                        de tipos e os embaralhou para fazer um livro de modelos de tipos. Lorem Ipsum
                                    </p>
                                </div>

                 ");
                WriteLiteral(@"           </div><!-- end col -->

                        </div>


                        <div class=""row"">
                            <div class=""col-12"">
                                <div class=""table-responsive"">
                                    <table class=""table mt-4"">
                                        <thead>
                                            <tr>
                                                <th>");
#nullable restore
#line 55 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\VisualizarPDF.cshtml"
                                               Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                                                <th>");
#nullable restore
#line 56 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\VisualizarPDF.cshtml"
                                               Write(Html.DisplayNameFor(model => model.Documento));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                                                <th>");
#nullable restore
#line 57 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\VisualizarPDF.cshtml"
                                               Write(Html.DisplayNameFor(model => model.Ativo));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                                                <th>");
#nullable restore
#line 58 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\VisualizarPDF.cshtml"
                                               Write(Html.DisplayNameFor(model => model.TipoFornecedor));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                                            </tr>\r\n                                        </thead>\r\n                                        <tbody>\r\n");
#nullable restore
#line 62 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\VisualizarPDF.cshtml"
                                             foreach (var item in Model)
                                            {


#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <tr>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 67 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\VisualizarPDF.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 70 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\VisualizarPDF.cshtml"
                                                   Write(this.FormataDocumento(item.TipoFornecedor, item.Documento));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 73 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\VisualizarPDF.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.Ativo));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                    </td>\r\n\r\n\r\n");
#nullable restore
#line 77 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\VisualizarPDF.cshtml"
                                                     if (item.TipoFornecedor == 1)
                                                    {


#line default
#line hidden
#nullable disable
                WriteLiteral("                                                        <td><span class=\"badge badge-warning\">Pessoa Física</span></td>\r\n");
#nullable restore
#line 81 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\VisualizarPDF.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                        <td><span class=\"badge badge-success\">Pessoa Jurídica</span></td>\r\n");
#nullable restore
#line 85 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\VisualizarPDF.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                </tr>\r\n");
#nullable restore
#line 88 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\VisualizarPDF.cshtml"

                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                        </tbody>
                                    </table>
                                </div> <!-- end table-responsive-->
                            </div> <!-- end col -->
                        </div>
                        <!-- end row -->


                    </div> <!-- end card-body-->
                </div> <!-- end card -->
            </div> <!-- end col-->
        </div>
        <!-- end row -->

    </div>
    <!-- container -->



    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8e8f5f7926a770a28cf4e505ec8fa8155d5e6e6a17198", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8e8f5f7926a770a28cf4e505ec8fa8155d5e6e6a18298", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
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
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DevIO.App.ViewModels.FornecedorViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591