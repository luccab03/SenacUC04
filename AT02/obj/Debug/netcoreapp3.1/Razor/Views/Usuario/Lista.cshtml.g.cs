#pragma checksum "/Users/luccab/OneDrive/Curso/UC04/AT02/Views/Usuario/Lista.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9f103f3e3ac821ac85ff29cf75b7f95e4209f0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Lista), @"mvc.1.0.view", @"/Views/Usuario/Lista.cshtml")]
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
#line 1 "/Users/luccab/OneDrive/Curso/UC04/AT02/Views/_ViewImports.cshtml"
using AT02;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/luccab/OneDrive/Curso/UC04/AT02/Views/_ViewImports.cshtml"
using AT02.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9f103f3e3ac821ac85ff29cf75b7f95e4209f0c", @"/Views/Usuario/Lista.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8df5e293c69c8455a3fc238493913b0807e04a1c", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Lista : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/luccab/OneDrive/Curso/UC04/AT02/Views/Usuario/Lista.cshtml"
  
    ViewData["Title"] = "Listagem de Usuários";
    UsuarioDatabase ud = new UsuarioDatabase();
    List<Usuario> lista = ud.Query();

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Usuários cadastrados</h2>\n");
#nullable restore
#line 8 "/Users/luccab/OneDrive/Curso/UC04/AT02/Views/Usuario/Lista.cshtml"
 foreach (Usuario usr in lista)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <ul>\n        <li>Nome: ");
#nullable restore
#line 11 "/Users/luccab/OneDrive/Curso/UC04/AT02/Views/Usuario/Lista.cshtml"
             Write(usr.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n        <ul>\n            <li>Id: ");
#nullable restore
#line 13 "/Users/luccab/OneDrive/Curso/UC04/AT02/Views/Usuario/Lista.cshtml"
               Write(usr.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n            <li>Login: ");
#nullable restore
#line 14 "/Users/luccab/OneDrive/Curso/UC04/AT02/Views/Usuario/Lista.cshtml"
                  Write(usr.Login);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n            <li>Senha: ");
#nullable restore
#line 15 "/Users/luccab/OneDrive/Curso/UC04/AT02/Views/Usuario/Lista.cshtml"
                  Write(usr.Senha);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n            <li>Nascimento: ");
#nullable restore
#line 16 "/Users/luccab/OneDrive/Curso/UC04/AT02/Views/Usuario/Lista.cshtml"
                       Write(usr.Nascimento.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n");
#nullable restore
#line 17 "/Users/luccab/OneDrive/Curso/UC04/AT02/Views/Usuario/Lista.cshtml"
             if (usr.Tipo == 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <li>Tipo: Administrador</li> ");
#nullable restore
#line 17 "/Users/luccab/OneDrive/Curso/UC04/AT02/Views/Usuario/Lista.cshtml"
                                                               }  
            else if (usr.Tipo == 1) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <li>Tipo: Colaborador</li> ");
#nullable restore
#line 18 "/Users/luccab/OneDrive/Curso/UC04/AT02/Views/Usuario/Lista.cshtml"
                                                                 }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\n    </ul>\n");
#nullable restore
#line 21 "/Users/luccab/OneDrive/Curso/UC04/AT02/Views/Usuario/Lista.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
