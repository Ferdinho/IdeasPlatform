#pragma checksum "C:\Users\ferdi\Downloads\CodingDojo\C#\ManyToMany\FinalExam\FinalExams\Views\Home\see.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "793eef324599d3db6163b5855f9e68ed12421d95"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_see), @"mvc.1.0.view", @"/Views/Home/see.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/see.cshtml", typeof(AspNetCore.Views_Home_see))]
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
#line 1 "C:\Users\ferdi\Downloads\CodingDojo\C#\ManyToMany\FinalExam\FinalExams\Views\_ViewImports.cshtml"
using FinalExams;

#line default
#line hidden
#line 2 "C:\Users\ferdi\Downloads\CodingDojo\C#\ManyToMany\FinalExam\FinalExams\Views\_ViewImports.cshtml"
using FinalExams.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"793eef324599d3db6163b5855f9e68ed12421d95", @"/Views/Home/see.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cf8ea66cfa01045cbc7da8f8cc9736f3236cce6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_see : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Idea>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(13, 49, true);
            WriteLiteral("\r\n    <a href=\"/dashboard\"> Home</a>\r\n\r\n\r\n<h4><a>");
            EndContext();
            BeginContext(63, 22, false);
#line 6 "C:\Users\ferdi\Downloads\CodingDojo\C#\ManyToMany\FinalExam\FinalExams\Views\Home\see.cshtml"
  Write(Model.creator.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(85, 12, true);
            WriteLiteral("</a> says : ");
            EndContext();
            BeginContext(98, 17, false);
#line 6 "C:\Users\ferdi\Downloads\CodingDojo\C#\ManyToMany\FinalExam\FinalExams\Views\Home\see.cshtml"
                                     Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(115, 210, true);
            WriteLiteral("</h4><br>\r\n<h5>People who liked this post :</h5>\r\n\r\n<table class=\"table\">\r\n  <thead>\r\n    <tr>\r\n      <th scope=\"col\">Alias</th>\r\n      <th scope=\"col\">Real Name</th>\r\n    </tr>\r\n  </thead>\r\n  <tbody>\r\n      \r\n");
            EndContext();
#line 18 "C:\Users\ferdi\Downloads\CodingDojo\C#\ManyToMany\FinalExam\FinalExams\Views\Home\see.cshtml"
       if (Model==null){}
      else{
      

#line default
#line hidden
#line 20 "C:\Users\ferdi\Downloads\CodingDojo\C#\ManyToMany\FinalExam\FinalExams\Views\Home\see.cshtml"
       foreach(var i in Model.people){

#line default
#line hidden
            BeginContext(405, 22, true);
            WriteLiteral("    <tr>\r\n      <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 427, "\"", 455, 2);
            WriteAttributeValue("", 434, "/users/", 434, 7, true);
#line 22 "C:\Users\ferdi\Downloads\CodingDojo\C#\ManyToMany\FinalExam\FinalExams\Views\Home\see.cshtml"
WriteAttributeValue("", 441, i.User.UserId, 441, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(456, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(458, 15, false);
#line 22 "C:\Users\ferdi\Downloads\CodingDojo\C#\ManyToMany\FinalExam\FinalExams\Views\Home\see.cshtml"
                                     Write(i.User.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(473, 21, true);
            WriteLiteral("</a></td>\r\n      <td>");
            EndContext();
            BeginContext(495, 16, false);
#line 23 "C:\Users\ferdi\Downloads\CodingDojo\C#\ManyToMany\FinalExam\FinalExams\Views\Home\see.cshtml"
     Write(i.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(511, 18, true);
            WriteLiteral("</td>\r\n    </tr>\r\n");
            EndContext();
#line 25 "C:\Users\ferdi\Downloads\CodingDojo\C#\ManyToMany\FinalExam\FinalExams\Views\Home\see.cshtml"
    }

#line default
#line hidden
#line 25 "C:\Users\ferdi\Downloads\CodingDojo\C#\ManyToMany\FinalExam\FinalExams\Views\Home\see.cshtml"
     
}

#line default
#line hidden
            BeginContext(539, 20, true);
            WriteLiteral("  </tbody>\r\n</table>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Idea> Html { get; private set; }
    }
}
#pragma warning restore 1591
