#pragma checksum "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20f156b4f3d37f1384b8829e718a1822496af5b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fornecedores__DetalhesEndereco), @"mvc.1.0.view", @"/Views/Fornecedores/_DetalhesEndereco.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20f156b4f3d37f1384b8829e718a1822496af5b0", @"/Views/Fornecedores/_DetalhesEndereco.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f4e717c4124c55203fe493fa8cdf7ca43650315", @"/Views/_ViewImports.cshtml")]
    public class Views_Fornecedores__DetalhesEndereco : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DevIO.App.ViewModels.FornecedorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 5 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
  
    ViewData["Title"] = "Endereço Fornecedor";
    var controller = this.ViewContext.RouteData.Values["controller"].ToString();


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<p>

</p>



    <div class=""container-fluid"">

        <div class=""row"">
            <div class=""col-12"">

                <div class=""card"">
                    <div class=""card-body"">

                        <div class=""col-md-12 col py-1 "">
                            <h4 class=""header-title"">Lista de Endereço</h4>
                            <p supress-by-claim-name=""Fornecedor"" supress-by-claim-value=""Adicionar"">
                                <a href=""#"" class=""btn btn-outline-primary""");
            BeginWriteAttribute("onclick", " onclick=\"", 712, "\"", 765, 3);
            WriteAttributeValue("", 722, "ExibirModalAdicionarEndereco(\'", 722, 30, true);
#nullable restore
#line 28 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
WriteAttributeValue("", 752, controller, 752, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 763, "\')", 763, 2, true);
            EndWriteAttribute();
            WriteLiteral(@">Adicionar</a>
                            </p>
                        </div>

                        <div class=""tab-content"">
                            <div class=""tab-pane show active"" id=""striped-rows-preview"">
                                <div class=""table-responsive-sm"">
                                    <table id=""DetalheEndereco"" class=""table table-striped table-centered mb-0"">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>");
#nullable restore
#line 39 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                               Write(Html.DisplayNameFor(model => model.Endereco.Logradouro));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                                <th>");
#nullable restore
#line 40 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                               Write(Html.DisplayNameFor(model => model.Endereco.Numero));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                                <th>");
#nullable restore
#line 41 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                               Write(Html.DisplayNameFor(model => model.Endereco.Complemento));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                                <th>");
#nullable restore
#line 42 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                               Write(Html.DisplayNameFor(model => model.Endereco.Bairro));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                                <th>");
#nullable restore
#line 43 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                               Write(Html.DisplayNameFor(model => model.Endereco.Cep));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                                <th>");
#nullable restore
#line 44 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                               Write(Html.DisplayNameFor(model => model.Endereco.Cidade));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                                <th>");
#nullable restore
#line 45 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                               Write(Html.DisplayNameFor(model => model.Endereco.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                                <th>Ações</th>\r\n                                            </tr>\r\n                                        </thead>\r\n                                        <tbody>\r\n\r\n\r\n");
#nullable restore
#line 52 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                             foreach (var item in Model.Enderecos)
                                            {



#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 58 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                                   Write(Html.DisplayFor(model => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 61 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                                   Write(Html.DisplayFor(model => item.Logradouro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 64 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                                   Write(Html.DisplayFor(model => item.Numero));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 67 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                                   Write(Html.DisplayFor(model => item.Complemento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 70 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                                   Write(Html.DisplayFor(model => item.Bairro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 73 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                                   Write(Html.DisplayFor(model => item.Cep));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 76 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                                   Write(Html.DisplayFor(model => item.Cidade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 79 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                                   Write(Html.DisplayFor(model => item.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                    </td>
                                                    <td class=""table-action"">
                                                        <a supress-by-claim-name=""Fornecedor"" supress-by-claim-value=""Editar"" class=""btn btn-warning"" data-toggle=""tooltip"" data-placement=""top"" title=""Editar""");
            BeginWriteAttribute("onclick", " onclick=\"", 4513, "\"", 4575, 6);
            WriteAttributeValue("", 4523, "ExibirModalEditarEndereco(\'", 4523, 27, true);
#nullable restore
#line 82 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
WriteAttributeValue("", 4550, item.Id, 4550, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4558, "\',", 4558, 2, true);
            WriteAttributeValue(" ", 4560, "\'", 4561, 2, true);
#nullable restore
#line 82 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
WriteAttributeValue("", 4562, controller, 4562, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4573, "\')", 4573, 2, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"mdi mdi-pencil\"></i> </a>\r\n                                                        <a supress-by-claim-name=\"Fornecedor\" supress-by-claim-value=\"Excluir\" class=\"btn btn-danger\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Deletar\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4822, "\"", 4895, 7);
            WriteAttributeValue("", 4832, "ExibirModalExcluir(\'", 4832, 20, true);
#nullable restore
#line 83 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
WriteAttributeValue("", 4852, item.Id, 4852, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4860, "\',\'", 4860, 3, true);
#nullable restore
#line 83 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
WriteAttributeValue("", 4863, item.Logradouro, 4863, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4879, "\',\'", 4879, 3, true);
#nullable restore
#line 83 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
WriteAttributeValue("", 4882, controller, 4882, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4893, "\')", 4893, 2, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"mdi mdi-delete\"></i> </a>\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 86 "C:\src\AppMvcAspNetCoreVendas\src\DevIO.App\Views\Fornecedores\_DetalhesEndereco.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </tbody>
                                    </table>
                                </div>
                            </div>

                        </div>

                    </div> <!-- end card body-->
                </div> <!-- end card -->
            </div><!-- end col-->
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DevIO.App.ViewModels.FornecedorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
