#pragma checksum "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\Pages\TestUpdatedate.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a99498eb169e18c09839b70e8af58fa1630e6eea"
// <auto-generated/>
#pragma warning disable 1591
namespace SupportMonitorBlazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\_Imports.razor"
using SupportMonitorBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\_Imports.razor"
using SupportMonitorBlazor.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/update")]
    public partial class TestUpdatedate : TestUpdatedateBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>TestUpdatedate</h3>\r\n");
            __builder.OpenElement(1, "button");
            __builder.AddAttribute(2, "class", "btn btn-primary");
            __builder.AddAttribute(3, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 5 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\Pages\TestUpdatedate.razor"
                                          ()=>TestUpdateDB()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(4, "Try to update DB");
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\r\n\r\n");
#nullable restore
#line 7 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\Pages\TestUpdatedate.razor"
 if (DiskSpaceProps == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(6, "<p>DiskSpaceProps er null</p>");
#nullable restore
#line 8 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\Pages\TestUpdatedate.razor"
                              }
else
{



#line default
#line hidden
#nullable disable
            __builder.AddContent(7, "    ");
            __builder.OpenElement(8, "table");
            __builder.AddAttribute(9, "class", "table table-hover");
            __builder.AddMarkupContent(10, "\r\n\r\n        ");
            __builder.AddMarkupContent(11, @"<thead>
            <tr>
                <th scope=""col"">#</th>
                <th scope=""col"">Id</th>
                <th scope=""col"">TMSID</th>
                <th scope=""col"">kategori</th>
                <th>Status</th>
                <th>Kritiske feil</th>

            </tr>
        </thead>
        ");
            __builder.OpenElement(12, "tbody");
            __builder.AddMarkupContent(13, "\r\n");
#nullable restore
#line 27 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\Pages\TestUpdatedate.razor"
             foreach (var space in DiskSpaceProps)
            {


#line default
#line hidden
#nullable disable
            __builder.AddContent(14, "            ");
            __builder.OpenElement(15, "tr");
            __builder.AddMarkupContent(16, "\r\n\r\n                ");
            __builder.OpenElement(17, "th");
            __builder.AddAttribute(18, "scope", "row");
            __builder.AddContent(19, 
#nullable restore
#line 32 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\Pages\TestUpdatedate.razor"
                                 space.Id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n                ");
            __builder.OpenElement(21, "td");
            __builder.AddContent(22, 
#nullable restore
#line 33 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\Pages\TestUpdatedate.razor"
                     space.Id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n                ");
            __builder.OpenElement(24, "td");
            __builder.AddContent(25, 
#nullable restore
#line 34 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\Pages\TestUpdatedate.razor"
                     space.TmsId

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n                ");
            __builder.OpenElement(27, "td");
            __builder.AddContent(28, 
#nullable restore
#line 35 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\Pages\TestUpdatedate.razor"
                     space.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n                ");
            __builder.OpenElement(30, "td");
            __builder.AddContent(31, 
#nullable restore
#line 36 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\Pages\TestUpdatedate.razor"
                     space.Actualsize

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n                ");
            __builder.OpenElement(33, "td");
            __builder.AddContent(34, 
#nullable restore
#line 37 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\Pages\TestUpdatedate.razor"
                     space.MaxSize

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n             \r\n              \r\n                ");
            __builder.OpenElement(36, "td");
            __builder.OpenElement(37, "button");
            __builder.AddAttribute(38, "class", "btn btn-primary");
            __builder.AddAttribute(39, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 40 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\Pages\TestUpdatedate.razor"
                                                              ()=>TestUpdateDB()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(40, "Detaljer");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n");
#nullable restore
#line 43 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\Pages\TestUpdatedate.razor"

            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(43, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n");
#nullable restore
#line 48 "C:\Users\morten.olsen\source\repos\Blazor\SupportPrototype\SupportMonitorBlazor\SupportMonitorBlazor\Pages\TestUpdatedate.razor"

}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
